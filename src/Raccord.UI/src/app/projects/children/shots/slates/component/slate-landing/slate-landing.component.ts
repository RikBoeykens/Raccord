import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MdDialog } from '@angular/material';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { FullSlate } from "../../model/full-slate.model";
import { Slate } from "../../model/slate.model";
import { SlateHttpService } from "../../service/slate-http.service";
import { LoadingService } from "../../../../../../loading/service/loading.service";
import { DialogService } from "../../../../../../shared/service/dialog.service";
import { ChooseSceneDialog, ChooseShootingDayDialog } from "../../../../../index";
import { SceneSummary } from "../../../../scenes/model/scene-summary.model";
import { Scene } from "../../../../scenes/model/scene.model";
import { ShootingDay } from "../../../../shooting-days/index";
import { TakeHttpService } from "../../../takes/service/take-http.service";
import { Take } from "../../../takes/model/take.model";

@Component({
    templateUrl: 'slate-landing.component.html',
})
export class SlateLandingComponent {

    slate: FullSlate;
    viewSlate: Slate;
    project: ProjectSummary;
    availableScenes: SceneSummary[] = [];
    availableShootingDays: ShootingDay[] = [];

    constructor(
        private _slateHttpService: SlateHttpService,
        private _takeHttpService: TakeHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private _dialog: MdDialog
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { slate: FullSlate, project: ProjectSummary, scenes: SceneSummary[], shootingDays: ShootingDay[] }) => {
            this.slate = data.slate;
            this.viewSlate = new Slate(data.slate);
            this.project = data.project;
            this.availableScenes = data.scenes;
            this.availableShootingDays = data.shootingDays;
        });
    }

    getSlate(){
        let loadingId = this._loadingService.startLoading();

        this._slateHttpService.get(this.slate.id).then(data => {
            this.slate = data;
            this.viewSlate = new Slate(data);
            this._loadingService.endLoading(loadingId);
        });
    }

    updateSlate(){
        let loadingId = this._loadingService.startLoading();

        this._slateHttpService.post(this.viewSlate).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getSlate();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    chooseScene(){
        let sceneDialog = this._dialog.open(ChooseSceneDialog, {data: this.availableScenes});
        sceneDialog.afterClosed().subscribe(scene=> {
            if(scene){
                this.slate.scene = new Scene(scene);
                this.viewSlate.scene = new Scene(scene);

                this.updateSlate();
            }
        });
    }
    
    chooseShootingDay(){
        let shootingDayDialog = this._dialog.open(ChooseShootingDayDialog, {data: this.availableShootingDays});
        shootingDayDialog.afterClosed().subscribe(shootingDay=> {
            if(shootingDay){
                this.slate.shootingDay = new ShootingDay(shootingDay);
                this.viewSlate.shootingDay = new ShootingDay(shootingDay);

                this.updateSlate();
            }
        });
    }

    addTake(){
        let loadingId = this._loadingService.startLoading();

        let newTake = new Take();
        newTake.slate = this.viewSlate;

        this._takeHttpService.post(newTake).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getSlate();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    updateTake(take: Take){
        let loadingId = this._loadingService.startLoading();

        this._takeHttpService.post(take).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getSlate();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeTake(take: Take){
        let loadingId = this._loadingService.startLoading();

        this._takeHttpService.delete(take.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getSlate();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}