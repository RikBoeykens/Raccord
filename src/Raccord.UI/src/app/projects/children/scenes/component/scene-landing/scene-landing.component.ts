import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SceneHttpService } from '../../service/scene-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { FullScene } from '../../model/full-scene.model';
import { Scene } from '../../model/scene.model';
import { ProjectSummary } from '../../../../model/project-summary.model';

@Component({
    templateUrl: 'scene-landing.component.html',
})
export class SceneLandingComponent {

    scene: FullScene;
    viewScene: Scene;
    project: ProjectSummary;

    constructor(
        private _sceneHttpService: SceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { scene: FullScene, project: ProjectSummary }) => {
            this.scene = data.scene;
            this.viewScene = new Scene(data.scene);
            this.project = data.project;
        });
    }

    getScene(){
        let loadingId = this._loadingService.startLoading();

        this._sceneHttpService.get(this.scene.id).then(data => {
            this.scene = data;
            this.viewScene = new Scene(data);
            this._loadingService.endLoading(loadingId);
        });
    }

    updateScene(){
        let loadingId = this._loadingService.startLoading();

        this._sceneHttpService.post(this.viewScene).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScene();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}