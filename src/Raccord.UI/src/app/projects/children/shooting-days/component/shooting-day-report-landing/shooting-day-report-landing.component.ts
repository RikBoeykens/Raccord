import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { FullShootingDay } from "../../model/full-shooting-day.model";
import { ShootingDayHttpService } from "../../service/shooting-day-http.service";
import { TimeHelpers } from "../../../../../shared/helpers/time.helpers";
import { EntityType } from "../../../../../shared/enums/entity-type.enum";
import { ShootingDaySceneHttpService } from "../../scenes/service/shooting-day-scene-http.service";
import { SelectedEntity } from "../../../../../shared/model/selected-entity.model";
import { ShootingDayScene } from "../../scenes/model/shooting-day-scene.model";
import { ShootingDaySceneScene } from "../../scenes/model/shooting-day-scene-scene.model";
import { Completion } from "../../../../../shared/enums/completion.enum";
import { MdDialog } from "@angular/material";
import { EditShootingDaySceneDialog } from "../../scenes/component/edit-shooting-day-scene-dialog/edit-shooting-day-scene-dialog.component";
import { TimespanHelpers } from "../../../../../shared/helpers/timespan.helpers";
import { ShootingDay } from '../..';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';

@Component({
    templateUrl: 'shooting-day-report-landing.component.html',
})
export class ShootingDayReportLandingComponent {

    shootingDay: ShootingDayWrapper;
    project: ProjectSummary;
    sceneType: EntityType[] = [EntityType.scene];

    constructor(
        private _shootingDayHttpService: ShootingDayHttpService,
        private _shootingDaySceneHttpService: ShootingDaySceneHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _route: ActivatedRoute,
        private _router: Router,
        private _dialog: MdDialog
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { shootingDay: FullShootingDay, project: ProjectSummary }) => {
            this.shootingDay = new ShootingDayWrapper(data.shootingDay);
            this.project = data.project;
        });
    }

    getShootingDay() {
        this._loadingWrapperService.Load(
            this._shootingDayHttpService.get(this.shootingDay.id),
            (data) => this.shootingDay = new ShootingDayWrapper(data)
        );
    }

    updateShootingDay() {
        this.setTimes(this.shootingDay);
        this._loadingWrapperService.Load(
            this._shootingDayHttpService.post(new ShootingDay({
                id: this.shootingDay.id,
                number: this.shootingDay.number,
                date: this.shootingDay.date,
                start: this.shootingDay.start,
                end: this.shootingDay.end,
                turn: this.shootingDay.turn,
                overTime: this.shootingDay.overTime,
                completed: this.shootingDay.completed,
                scheduleDayID: this.shootingDay.scheduleDayID,
                callsheetID: this.shootingDay.callsheetID,
                crewUnitID: this.shootingDay.crewUnit.id
            })),
            () => null,
            () => this.getShootingDay()
        );
    }

    getScenes(){
        this._loadingWrapperService.Load(
            this._shootingDaySceneHttpService.getScenes(this.shootingDay.id),
            (data) => this.shootingDay.scenes = data
        );
    }

    getNotStartedScenes(){
        return this.shootingDay.scenes.filter((scene: ShootingDaySceneScene)=>{ return scene.completion == Completion.notStarted });
    }
    
    getPartCompletedScenes(){
        return this.shootingDay.scenes.filter((scene: ShootingDaySceneScene)=>{ return scene.completion == Completion.partCompleted });
    }
    
    getCompletedScenes(){
        return this.shootingDay.scenes.filter((scene: ShootingDaySceneScene)=>{ return scene.completion == Completion.completed });
    }
    
    getTodayScenesCount(){
        return this.getCompletedScenes().length;
    }
    
    getTodayScenePageCount(){
        let result = 0;
        this.shootingDay.scenes.forEach((shootingDayScene: ShootingDaySceneScene)=>{
            result += shootingDayScene.pageLength;
        });
        return result;
    }
    
    getTodayTimingsCount(){
        let result = 0;
        this.shootingDay.scenes.forEach((shootingDayScene: ShootingDaySceneScene)=>{
            result += TimespanHelpers.getTimespanNumber(shootingDayScene.timings);
        });
        return result;
    }
    
    getTotalTimingsCount(){
        let result = TimespanHelpers.getTimespanNumber(this.shootingDay.previouslyCompletedTimingsCount);
        this.shootingDay.scenes.forEach((shootingDayScene: ShootingDaySceneScene)=>{
            result += TimespanHelpers.getTimespanNumber(shootingDayScene.timings);
        });
        return result;
    }

    addShootingDayScene(scene: SelectedEntity) {
        let newShootingDayScene = new ShootingDayScene();
        newShootingDayScene.sceneID = scene.entityId;
        newShootingDayScene.shootingDayID = this.shootingDay.id;
        newShootingDayScene.completion = Completion.partCompleted;

        this._loadingWrapperService.Load(
            this._shootingDaySceneHttpService.post(newShootingDayScene),
            () => this.getScenes()
        );
    }

    editShootingDayScene(scene: ShootingDaySceneScene){
        let sceneDialog = this._dialog.open(EditShootingDaySceneDialog, {data: scene});
        sceneDialog.afterClosed().subscribe(scene=> {
            if(scene){
                this.updateShootingDayScene(scene);
            }
        });
    }
    
    updateShootingDayScene(scene: ShootingDaySceneScene){
        let shootingDayScene = new ShootingDayScene();
        shootingDayScene.id = scene.id;
        shootingDayScene.completion = scene.completion;
        shootingDayScene.locationSetID = scene.locationSet.id;
        shootingDayScene.pageLength = scene.pageLength;
        shootingDayScene.timings = scene.timings;

        this._loadingWrapperService.Load(
            this._shootingDaySceneHttpService.post(shootingDayScene),
            () => this.getScenes()
        );
    }

    removeShootingDayScene(scene: ShootingDaySceneScene) {
        this._loadingWrapperService.Load(
            this._shootingDaySceneHttpService.delete(scene.id),
            () => this.getScenes()
        );
    }

    private setTimes(shootingDay: ShootingDayWrapper) {
        shootingDay.start = TimeHelpers.getTime(shootingDay.startString);
        shootingDay.turn = TimeHelpers.getTime(shootingDay.turnString);
        shootingDay.end = TimeHelpers.getTime(shootingDay.endString);
    }
}

export class ShootingDayWrapper extends FullShootingDay{
    startString: string;
    endString: string;
    turnString: string;
    constructor(obj: FullShootingDay){
        super(obj);
        this.startString = TimeHelpers.getTimeString(obj.start);
        this.endString = TimeHelpers.getTimeString(obj.end);
        this.turnString = TimeHelpers.getTimeString(obj.turn);
    }    
}