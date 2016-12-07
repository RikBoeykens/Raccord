import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SceneService } from '../../service/scene.service';
import { SceneSummary } from '../../model/scene-summary.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';

@Component({
    templateUrl: 'scenes-list.component.html',
})
export class ScenesListComponent extends OnInit {

    scenes: SceneSummary[] = [];
    project: ProjectSummary;

    constructor(
        private _sceneService: SceneService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ) {
        super();
    }

    ngOnInit() {
        this._route.data.subscribe((data: { scenes: SceneSummary[], project: ProjectSummary }) => {
            this.scenes = data.scenes;
            this.project = data.project;
        });
    }

    getScenes(){
        
        let loadingId = this._loadingService.startLoading();

        this._sceneService.getAll(this.project.id).then(data => {
            this.scenes = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    remove(scene: SceneSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove scene #${scene.number}`)){

            let loadingId = this._loadingService.startLoading();

            this._sceneService.delete(scene.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                }else{
                    this._dialogService.success('The scene was successfully removed');
                    this.getScenes();
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }

    }
}