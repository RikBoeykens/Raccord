import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MdDialog } from '@angular/material';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { FullSlate } from '../../model/full-slate.model';
import { Slate } from '../../model/slate.model';
import { SlateHttpService } from '../../service/slate-http.service';
import { LoadingService } from "../../../../../../loading/service/loading.service";
import { DialogService } from "../../../../../../shared/service/dialog.service";
import { ChooseSceneDialog, ChooseShootingDayDialog } from "../../../../../index";
import { SceneSummary } from "../../../../scenes/model/scene-summary.model";
import { Scene } from "../../../../scenes/model/scene.model";
import { ShootingDay } from "../../../../shooting-days/index";
import { TakeHttpService } from "../../../takes/service/take-http.service";
import { Take } from "../../../takes/model/take.model";
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';

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
        private _loadingWrapperService: LoadingWrapperService,
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

    getSlate() {
        this._loadingWrapperService.Load(
            this._slateHttpService.get(this.slate.id),
            (data) => {
                this.slate = data;
                this.viewSlate = new Slate(data);
            }
        );
    }

    updateSlate() {
        this._loadingWrapperService.Load(
            this._slateHttpService.post(this.viewSlate),
            () => this.getSlate()
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

    public chooseShootingDay(){
        let shootingDayDialog = this._dialog.open(
            ChooseShootingDayDialog, {data: this.availableShootingDays});
        shootingDayDialog.afterClosed().subscribe((shootingDay) => {
            if (shootingDay) {
                this.slate.shootingDay = new ShootingDay(shootingDay);
                this.viewSlate.shootingDay = new ShootingDay(shootingDay);

                this.updateSlate();
            }
        });
    }

    public addTake() {
        let newTake = new Take();
        newTake.slate = this.viewSlate;
        this._loadingWrapperService.Load(
            this._takeHttpService.post(newTake),
            () => this.getSlate()
        );
    }

    public updateTake(take: Take){
        this._loadingWrapperService.Load(
            this._takeHttpService.post(take),
            () => this.getSlate()
        );
    }

    public removeTake(take: Take){
        this._loadingWrapperService.Load(
            this._takeHttpService.delete(take.id),
            () => this.getSlate()
        );
    }
}