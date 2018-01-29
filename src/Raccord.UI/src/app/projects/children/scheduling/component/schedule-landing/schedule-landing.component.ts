import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ScheduleDay } from '../../schedule-days/model/schedule-day.model';
import { FullScheduleDay } from '../../schedule-days/model/full-schedule-day.model';
import { ScheduleScene } from '../../schedule-scenes/model/schedule-scene.model';
import { ScheduleSceneScene } from '../../schedule-scenes/model/schedule-scene-scene.model';
import { Callsheet } from "../../../callsheets";
import { ShootingDay } from "../../../shooting-days";
import { ScheduleDayHttpService } from '../../schedule-days/service/schedule-day-http.service';
import { ScheduleDayNoteHttpService } from '../../schedule-day-notes/service/schedule-day-note-http.service';
import { ScheduleSceneHttpService } from '../../schedule-scenes/service/schedule-scene-http.service';
import { CallsheetHttpService } from '../../../callsheets/service/callsheet-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { SceneFilterRequest } from '../../../scenes/model/scene-filter-request.model';
import { BreakdownTypeSummary } from '../../../breakdowns/breakdown-types/model/breakdown-type-summary.model';
import { SceneHttpService } from '../../../scenes/service/scene-http.service';
import { PageRequest } from '../../../../../shared/children/paging/model/page-request.model';
import { AppSettings } from '../../../../../app.settings';
import { SceneSummary } from '../../../scenes/model/scene-summary.model';

@Component({
    templateUrl: 'schedule-landing.component.html',
})
export class ScheduleLandingComponent implements OnInit {

    scheduleDays: FullScheduleDay[] = [];
    project: ProjectSummary;
    viewNewScheduleDay: ScheduleDay;
    newScheduleDay: ScheduleDay;
    sceneType: EntityType[] = [EntityType.scene];
    filteredScenes: SceneSummary[] = [];
    sceneFilter: SceneFilterRequest = new SceneFilterRequest();
    breakdownTypes: BreakdownTypeSummary[];
    currentPage: PageRequest = new PageRequest({
        page: 1,
        pageSize: AppSettings.MAP_DEFAULT_PAGE_SIZE,
        full: false
    });
    totalScenes: number;

    constructor(
        private _scheduleDayHttpService: ScheduleDayHttpService,
        private _scheduleDayNoteHttpService: ScheduleDayNoteHttpService,
        private _scheduleSceneHttpService: ScheduleSceneHttpService,
        private _callsheetHttpService: CallsheetHttpService,
        private _sceneHttpService: SceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
        this.viewNewScheduleDay = new ScheduleDay();
    }

    ngOnInit() {
        this._route.data.subscribe((data: {
            scheduleDays: FullScheduleDay[],
            project: ProjectSummary,
            breakdownTypes: BreakdownTypeSummary[]
        }) => {
            this.scheduleDays = data.scheduleDays;
            this.project = data.project;
            this.sceneFilter.projectID = this.project.id;
            this.breakdownTypes = data.breakdownTypes;
        });
        this.resetNewScheduleDay();
    }


    getScheduleDays(){
        
        let loadingId = this._loadingService.startLoading();

        this._scheduleDayHttpService.getAll(this.project.id).then(data => {
            this.scheduleDays = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    resetNewScheduleDay(){
        this.viewNewScheduleDay = new ScheduleDay();
        this.viewNewScheduleDay.projectId = this.project.id;
        this.newScheduleDay = null;
    }

    addScheduleDay(){
        let loadingId = this._loadingService.startLoading();

        this.newScheduleDay = this.viewNewScheduleDay;

        this._scheduleDayHttpService.post(this.newScheduleDay).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScheduleDays();
                this.resetNewScheduleDay();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    getScheduledPageLength(scheduleDay: FullScheduleDay){
        let sum = 0;
        scheduleDay.scenes.map((scheduleScene: ScheduleSceneScene)=> sum+=scheduleScene.pageLength);
        return sum;
    }

    addScheduleScene(scene: SelectedEntity, scheduleDay: ScheduleDay){
        let loadingId = this._loadingService.startLoading();

        let newScheduleScene = new ScheduleScene();
        newScheduleScene.sceneId = scene.entityId;
        newScheduleScene.scheduleDayId = scheduleDay.id;

        this._scheduleSceneHttpService.post(newScheduleScene).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScheduleDays();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    addCallsheet(scheduleDay: FullScheduleDay){
        let callsheet = new Callsheet();
        callsheet.shootingDay = new ShootingDay();
        callsheet.shootingDay.id = scheduleDay.shootingDay.id;
        callsheet.projectId = this.project.id;

        let loadingId = this._loadingService.startLoading();

        this._callsheetHttpService.post(callsheet).then(data=>{
            if(typeof(data)== 'string'){
                this._dialogService.error(data);
            }else{
                this._router.navigate(["projects", this.project.id, "callsheets", data, "wizard", 1]);
            }
        }).catch()
        .then(()=> this._loadingService.endLoading(loadingId));
    }

    removeScheduleScene(event, scheduleScene: ScheduleScene){
        event.stopPropagation();
        let loadingId = this._loadingService.startLoading();

        this._scheduleSceneHttpService.delete(scheduleScene.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScheduleDays();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    publishDays(){
        let loadingId = this._loadingService.startLoading();

        this._scheduleDayHttpService.publish(this.project.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScheduleDays();
            }
        }).catch()
        .then(()=>
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
        this._sceneHttpService.filter(this.sceneFilter, this.currentPage).then(pagedData => {
            this.filteredScenes = pagedData.data;
            this.totalScenes = pagedData.pageInfo.total;
            this._loadingService.endLoading(loadingId);
        });
    }

    public getNextScenes() {
        this.currentPage.page++;
        let loadingId = this._loadingService.startLoading();
        this._sceneHttpService.filter(this.sceneFilter, this.currentPage).then(pagedData => {
            this.filteredScenes = this.filteredScenes.concat(pagedData.data);
            this.totalScenes = pagedData.pageInfo.total;
            this._loadingService.endLoading(loadingId);
        });
    }
}