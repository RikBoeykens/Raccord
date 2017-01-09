import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SceneHttpService } from '../../service/scene-http.service';
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
    viewNewScene: SceneSummary;
    newScene: SceneSummary;

    constructor(
        private _sceneHttpService: SceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ) {
        super();
        this.viewNewScene = new SceneSummary();
    }

    ngOnInit() {
        this._route.data.subscribe((data: { scenes: SceneSummary[], project: ProjectSummary }) => {
            this.scenes = data.scenes;
            this.project = data.project;
            this.resetNewScene();
        });
    }

    resetNewScene(){
        this.viewNewScene = new SceneSummary();
        this.viewNewScene.projectId = this.project.id;
        this.viewNewScene.intExt.projectId = this.project.id;
        this.viewNewScene.dayNight.projectId = this.project.id;
        this.viewNewScene.location.projectId = this.project.id;
        this.newScene = null;
    }

    getScenes(){
        
        let loadingId = this._loadingService.startLoading();

        this._sceneHttpService.getAll(this.project.id).then(data => {
            this.scenes = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    addScene(){
        let loadingId = this._loadingService.startLoading();

        this.newScene = this.viewNewScene;

        this._sceneHttpService.post(this.newScene).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScenes();
                this.resetNewScene();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    remove(scene: SceneSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove scene #${scene.number}`)){

            let loadingId = this._loadingService.startLoading();

            this._sceneHttpService.delete(scene.id).then(data=>{
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