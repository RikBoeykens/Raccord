import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { FullShootingDay } from "../../model/full-shooting-day.model";
import { ShootingDayHttpService } from "../../service/shooting-day-http.service";
import { TimeHelpers } from "../../../../../shared/helpers/time.helpers";
import { EntityType } from "../../../../../shared/enums/entity-type.enum";
import { ShootingDaySceneHttpService } from "../../scenes/service/shooting-day-scene-http.service";
import { SelectedEntity } from "../../../../../shared/model/selected-entity.model";
import { ShootingDayScene } from "../../scenes/model/shooting-day-scene.model";

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
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { shootingDay: FullShootingDay, project: ProjectSummary }) => {
            this.shootingDay = new ShootingDayWrapper(data.shootingDay);
            this.project = data.project;
        });
    }

    getShootingDay(){
        let loadingId = this._loadingService.startLoading();

        this._shootingDayHttpService.get(this.shootingDay.id).then(data => {
            this.shootingDay = new ShootingDayWrapper(data);
            this._loadingService.endLoading(loadingId);
        });
    }

    updateShootingDay(){
        let loadingId = this._loadingService.startLoading();

        this.setTimes(this.shootingDay);

        this._shootingDayHttpService.post(this.shootingDay).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
                this.getShootingDay();
            }else{
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    setTimes(shootingDay: ShootingDayWrapper){
        shootingDay.start = TimeHelpers.getTime(shootingDay.startString);
        shootingDay.turn = TimeHelpers.getTime(shootingDay.turnString);
        shootingDay.end = TimeHelpers.getTime(shootingDay.endString);
    }
    
    getScenes(){
        let loadingId = this._loadingService.startLoading();

        this._shootingDaySceneHttpService.getScenes(this.shootingDay.id).then(data => {
            this.shootingDay.scenes = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    addShootingDayScene(scene: SelectedEntity){
        let loadingId = this._loadingService.startLoading();

        let newShootingDayScene = new ShootingDayScene();
        newShootingDayScene.sceneID = scene.entityId;
        newShootingDayScene.shootingDayID = this.shootingDay.id;

        this._shootingDaySceneHttpService.post(newShootingDayScene).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScenes();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
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