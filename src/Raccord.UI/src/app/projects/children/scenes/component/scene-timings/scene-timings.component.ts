import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SceneHttpService } from '../../service/scene-http.service';
import { Scene } from '../../model/scene.model';
import { SceneSummary } from '../../model/scene-summary.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../shared/helpers/html-class.helpers';
import { TimespanHelpers } from "../../../../../shared/helpers/timespan.helpers";
import { ProjectPermissionEnum } from '../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';

@Component({
    templateUrl: 'scene-timings.component.html',
})
export class SceneTimingsComponent implements OnInit {

    scenes: SceneSummary[] = [];
    project: ProjectSummary;

    constructor(
        private _sceneHttpService: SceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { scenes: SceneSummary[], project: ProjectSummary }) => {
            this.scenes = data.scenes;
            this.project = data.project;
        });
    }

    getScenes(){
        
        let loadingId = this._loadingService.startLoading();

        this._sceneHttpService.getAll(this.project.id).then(data => {
            this.scenes = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    updateTiming(scene: Scene){
        let loadingId = this._loadingService.startLoading();

        this._sceneHttpService.post(scene).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
                this.getScenes();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    getTotalTimings(){
        let count = 0;
        this.scenes.forEach((scene: SceneSummary) => {
            count += TimespanHelpers.getTimespanNumber(scene.timing);
        });
        return count;
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canEditGeneral
        );
    }
}