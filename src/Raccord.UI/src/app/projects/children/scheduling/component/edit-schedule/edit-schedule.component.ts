import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ScheduleDay } from '../../schedule-days/model/schedule-day.model';
import { FullScheduleDay } from '../../schedule-days/model/full-schedule-day.model';
import { ScheduleScene } from '../../schedule-scenes/model/schedule-scene.model';
import { ScheduleSceneScene } from '../../schedule-scenes/model/schedule-scene-scene.model';
import { Callsheet } from '../../../callsheets';
import { ShootingDay } from '../../../shooting-days';
import { ScheduleDayHttpService } from '../../schedule-days/service/schedule-day-http.service';
import { ScheduleDayNoteHttpService } from
    '../../schedule-day-notes/service/schedule-day-note-http.service';
import { ScheduleSceneHttpService } from
    '../../schedule-scenes/service/schedule-scene-http.service';
import { CallsheetHttpService } from '../../../callsheets/service/callsheet-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { SceneFilterRequest } from '../../../scenes/model/scene-filter-request.model';
import { SceneHttpService } from '../../../scenes/service/scene-http.service';
import { PageRequest } from '../../../../../shared/children/paging/model/page-request.model';
import { AppSettings } from '../../../../../app.settings';
import { SceneSummary } from '../../../scenes/model/scene-summary.model';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../shared/helpers/html-class.helpers';
import { Element } from '@angular/compiler';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { SelectedBreakdown } from '../../../breakdowns/model/selected-breakdown.model';
import { CrewUnitNavEnum } from '../../../crew/crew-units/enum/crew-unit-nav.enum';
import { CrewUnitSummary } from '../../../crew/crew-units/model/crew-unit-summary.model';

@Component({
    templateUrl: 'edit-schedule.component.html',
})
export class EditScheduleComponent implements OnInit {

    public scheduleDays: ScheduleDayDragSceneWrapper[] = [];
    public project: ProjectSummary;
    public crewUnit: CrewUnitSummary;
    public viewNewScheduleDay: ScheduleDay;
    public newScheduleDay: ScheduleDay;
    public sceneType: EntityType[] = [EntityType.scene];
    public filteredScenes: SceneSummary[] = [];
    public sceneFilter: SceneFilterRequest = new SceneFilterRequest();
    public breakdown: SelectedBreakdown;
    public currentPage: PageRequest = new PageRequest({
        page: 1,
        pageSize: AppSettings.MAP_DEFAULT_PAGE_SIZE,
        full: false
    });
    public totalScenes: number;
    public draggingNewScene: boolean;
    public draggingSortScene: boolean;
    private newSceneBagName = 'new-scene-bag';
    private sortSceneBagName = 'sort-scene-bag';

    constructor(
        private _scheduleDayHttpService: ScheduleDayHttpService,
        private _scheduleDayNoteHttpService: ScheduleDayNoteHttpService,
        private _scheduleSceneHttpService: ScheduleSceneHttpService,
        private _callsheetHttpService: CallsheetHttpService,
        private _sceneHttpService: SceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _loadingWrapperService: LoadingWrapperService,
        private _route: ActivatedRoute,
        private _router: Router,
        private _dragulaService: DragulaService
    ) {
        this.viewNewScheduleDay = new ScheduleDay();
        _dragulaService.drag.subscribe((value) => {
            this.onSceneDrag(value[0]);
        });
        _dragulaService.dragend.subscribe((value) => {
            this.onSceneDragEnd(value[0]);
        });
        _dragulaService.dropModel.subscribe((value) => {
            this.onSceneDrop(value);
        });
        _dragulaService.over.subscribe((value) => {
            this.onOver(value.slice(1));
        });
        _dragulaService.out.subscribe((value) => {
            this.onOut(value.slice(1));
        });
        const newSceneBag: any = this._dragulaService.find(this.newSceneBagName);
        if (newSceneBag !== undefined ) {
            this._dragulaService.destroy(this.newSceneBagName);
        }
        _dragulaService.setOptions(this.newSceneBagName, {
            moves: (el, container, handle) => {
                return HtmlClassHelpers.hasClass(handle, 'drag-handle');
            },
            copy: true
        });

        const sortSceneBag: any = this._dragulaService.find(this.sortSceneBagName);
        if (sortSceneBag !== undefined ) {
            this._dragulaService.destroy(this.sortSceneBagName);
        }
        _dragulaService.setOptions(this.sortSceneBagName, {
            moves: (el, container, handle) => {
                return HtmlClassHelpers.hasClass(handle, 'drag-handle');
            }
        });
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            scheduleDays: FullScheduleDay[],
            project: ProjectSummary,
            crewUnit: CrewUnitSummary,
            breakdown: SelectedBreakdown
        }) => {
            this.scheduleDays = data.scheduleDays.map((scheduleDay) => {
                return new ScheduleDayDragSceneWrapper(scheduleDay);
            });
            this.project = data.project;
            this.crewUnit = data.crewUnit;
            this.sceneFilter.projectID = this.project.id;
            this.breakdown = data.breakdown;
        });
        this.resetNewScheduleDay();
    }

    public getScheduleDays() {

        let loadingId = this._loadingService.startLoading();

        this._scheduleDayHttpService.getAll(this.project.id, this.crewUnit.id).then((data) => {
            this.scheduleDays = data.map((scheduleDay) => {
                return new ScheduleDayDragSceneWrapper(scheduleDay);
            });
            this._loadingService.endLoading(loadingId);
        });
    }

    public resetNewScheduleDay() {
        this.viewNewScheduleDay = new ScheduleDay();
        this.viewNewScheduleDay.crewUnitID = this.crewUnit.id;
        this.newScheduleDay = null;
    }

    public addScheduleDay() {
        let loadingId = this._loadingService.startLoading();

        this.newScheduleDay = this.viewNewScheduleDay;

        this._scheduleDayHttpService.post(this.project.id, this.newScheduleDay).then((data) => {
            if (typeof(data) === 'string') {
                this._dialogService.error(data);
            }else {
                this.getScheduleDays();
                this.resetNewScheduleDay();
            }
        }).catch()
        .then(() =>
            this._loadingService.endLoading(loadingId)
        );
    }

    public getScheduledPageLength(scheduleDay: FullScheduleDay) {
        let sum = 0;
        scheduleDay.scenes.map((scheduleScene: ScheduleSceneScene) =>
            sum += scheduleScene.pageLength);
        return sum;
    }

    public addScheduleScene(scene: SceneSummary, scheduleDay: ScheduleDay) {
        let loadingId = this._loadingService.startLoading();

        let newScheduleScene = new ScheduleScene();
        newScheduleScene.sceneId = scene.id;
        newScheduleScene.scheduleDayId = scheduleDay.id;

        this._scheduleSceneHttpService.post(this.project.id, newScheduleScene).then((data) => {
            if (typeof(data) === 'string') {
                this._dialogService.error(data);
            }else {
                this.getScheduleDays();
            }
        }).catch()
        .then(() =>
            this._loadingService.endLoading(loadingId)
        );
    }

    public addCallsheet(scheduleDay: FullScheduleDay) {
        let callsheet = new Callsheet();
        callsheet.shootingDay = new ShootingDay();
        callsheet.shootingDay.id = scheduleDay.shootingDay.id;
        callsheet.crewUnitID = this.crewUnit.id;

        let loadingId = this._loadingService.startLoading();

        this._callsheetHttpService.post(callsheet).then((data) => {
            if (typeof(data) === 'string') {
                this._dialogService.error(data);
            }else {
                this._router.navigate([
                    'projects',
                    this.project.id,
                    'callsheets',
                    data,
                    'wizard',
                    1
                ]);
            }
        }).catch()
        .then(() => this._loadingService.endLoading(loadingId));
    }

    public removeScheduleScene(event, scheduleScene: ScheduleScene) {
        event.stopPropagation();
        let loadingId = this._loadingService.startLoading();

        this._scheduleSceneHttpService.delete(this.project.id, scheduleScene.id).then((data) => {
            if (typeof(data) === 'string') {
                this._dialogService.error(data);
            }else {
                this.getScheduleDays();
            }
        }).catch()
        .then(() =>
            this._loadingService.endLoading(loadingId)
        );
    }

    public publishDays() {
        let loadingId = this._loadingService.startLoading();

        this._scheduleDayHttpService.publish(this.project.id).then((data) => {
            if (typeof(data) === 'string') {
                this._dialogService.error(data);
            }else {
                this.getScheduleDays();
            }
        }).catch()
        .then(() =>
            this._loadingService.endLoading(loadingId)
        );
    }

    public filterScenes() {
        this.filteredScenes = [];
        this.currentPage = new PageRequest({
            page: 1,
            pageSize: AppSettings.MAP_DEFAULT_PAGE_SIZE,
            full: false
        });
        this.totalScenes = 0;
        let loadingId = this._loadingService.startLoading();
        this._sceneHttpService.filter(this.sceneFilter, this.currentPage).then((pagedData) => {
            this.filteredScenes = pagedData.data;
            this.totalScenes = pagedData.pageInfo.total;
            this._loadingService.endLoading(loadingId);
        });
    }

    public getNextScenes() {
        this.currentPage.page++;
        let loadingId = this._loadingService.startLoading();
        this._sceneHttpService.filter(this.sceneFilter, this.currentPage).then((pagedData) => {
            this.filteredScenes = this.filteredScenes.concat(pagedData.data);
            this.totalScenes = pagedData.pageInfo.total;
            this._loadingService.endLoading(loadingId);
        });
    }

    public getScheduleEditNavType() {
        return CrewUnitNavEnum.scheduleEdit;
    }

    private onSceneDrag(bag: string) {
        if (bag === this.newSceneBagName) {
            this.draggingNewScene = true;
        } else if (bag === this.sortSceneBagName) {
            this.draggingSortScene = true;
        }
    }
    private onSceneDragEnd(bag: string) {
        if (bag === this.newSceneBagName) {
            this.draggingNewScene = false;
        } else if (bag === this.sortSceneBagName) {
            this.draggingSortScene = false;
        }
    }
    private onSceneDrop(args) {
        let [bag, e, destinationContainer, originContainer] = args;
        if (bag === this.newSceneBagName) {
            // add scenes
            this.scheduleDays.forEach((scheduleDay: ScheduleDayDragSceneWrapper) => {
                scheduleDay.newScenes.forEach((scene: SceneSummary) => {
                    this.addScheduleScene(scene, scheduleDay);
                });
            });
        } else if (bag === this.sortSceneBagName) {
            // sort + update scenes
            let destinationDayId = parseInt(
                destinationContainer.getAttribute('data-schedule-day-id'),
                0
            );
            let originDayId = parseInt(
                originContainer.getAttribute('data-schedule-day-id'),
                0
            );
            let originDay = this.getScheduleDayById(originDayId);
            if (originDay) {
                this.sortScenes(originDay, () => {
                    if (destinationDayId !== originDayId) {
                        let scheduleSceneId = parseInt(
                            e.getAttribute('data-schedule-scene-id'),
                            0
                        );
                        this.moveScheduleScene(destinationDayId, scheduleSceneId);
                    }
                });
            }
        }
    }

    private moveScheduleScene(scheduleDayId: number, scheduleSceneId: number) {
        let loadingId = this._loadingService.startLoading();
        let scheduleDay = this.getScheduleDayById(scheduleDayId);
        if (scheduleDay) {
            let scene = this.getScheduleSceneById(scheduleDay, scheduleSceneId);
            if (scene) {
                let postScene = new ScheduleScene({
                    id: scheduleSceneId,
                    pageLength: scene.pageLength,
                    scheduleDayId,
                    sceneId: scene.scene.id,
                });
                if (scene.locationSet.id !== 0) {
                    postScene.locationSetId = scene.locationSet.id;
                }
                this._scheduleSceneHttpService.post(this.project.id, postScene).then((data) => {
                    if (typeof(data) === 'string') {
                        this._dialogService.error(data);
                    }else {
                        this.sortScenes(scheduleDay, null);
                    }
                }).catch()
                .then(() =>
                    this._loadingService.endLoading(loadingId)
                );
            }
        }
    }

    private onOver(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.addClass(el, 'hovering');
    }

    private onOut(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.removeClass(el, 'hovering');
    }

    private sortScenes(scheduleDay: ScheduleDayDragSceneWrapper, onSorted) {

        this._loadingWrapperService.Load(
            this._scheduleSceneHttpService.sort(
                this.project.id,
                scheduleDay.id,
                this.getSortedOrder(scheduleDay)
            ),
            () => {
                if (onSorted) {
                    onSorted();
                }
            }
        );
    }

    private getSortedOrder(scheduleDay: ScheduleDayDragSceneWrapper): number[] {
        return scheduleDay.scenes.map((scene) => {
            return scene.id;
        });
    }

    private getScheduleDayById(scheduleDayId: number) {
        let foundDays = this.scheduleDays.filter((scheduleDay: ScheduleDayDragSceneWrapper) => {
            return scheduleDay.id === scheduleDayId;
        });
        if (!foundDays.length) {
            return null;
        }
        return foundDays[0];
    }

    private getScheduleSceneById(
        scheduleDay: ScheduleDayDragSceneWrapper,
        scheduleSceneId: number
    ) {
        let foundScenes = scheduleDay.scenes.filter((scheduleScene: ScheduleSceneScene) => {
            return scheduleScene.id === scheduleSceneId;
        });
        if (!foundScenes.length) {
            return null;
        }
        return foundScenes[0];
    }
}

// tslint:disable-next-line:max-classes-per-file
export class ScheduleDayDragSceneWrapper extends FullScheduleDay {
    public newScenes: SceneSummary[] = [];

    constructor(obj) {
        super(obj);
    }
}
