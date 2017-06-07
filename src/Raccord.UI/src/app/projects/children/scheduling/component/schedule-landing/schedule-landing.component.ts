import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ScheduleDay } from '../../schedule-days/model/schedule-day.model';
import { FullScheduleDay } from '../../schedule-days/model/full-schedule-day.model';
import { ScheduleScene } from '../../schedule-scenes/model/schedule-scene.model';
import { ScheduleDayHttpService } from '../../schedule-days/service/schedule-day-http.service';
import { ScheduleDayNoteHttpService } from '../../schedule-day-notes/service/schedule-day-note-http.service';
import { ScheduleSceneHttpService } from '../../schedule-scenes/service/schedule-scene-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';

@Component({
    templateUrl: 'schedule-landing.component.html',
})
export class ScheduleLandingComponent extends OnInit {

    scheduleDays: FullScheduleDay[] = [];
    project: ProjectSummary;
    viewNewScheduleDay: ScheduleDay;
    newScheduleDay: ScheduleDay;
    sceneType: EntityType[] = [EntityType.scene];

    constructor(
        private _scheduleDayHttpService: ScheduleDayHttpService,
        private _scheduleDayNoteHttpService: ScheduleDayNoteHttpService,
        private _scheduleSceneHttpService: ScheduleSceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
        super();
        this.viewNewScheduleDay = new ScheduleDay();
    }

    ngOnInit() {
        this._route.data.subscribe((data: { scheduleDays: FullScheduleDay[], project: ProjectSummary }) => {
            this.scheduleDays = data.scheduleDays;
            this.project = data.project;
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
}