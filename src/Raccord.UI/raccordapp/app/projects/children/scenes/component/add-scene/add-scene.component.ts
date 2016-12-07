import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SceneService } from '../../service/scene.service';
import { SceneSummary } from '../../model/scene-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { CanComponentDeactivate } from '../../../../../shared/interface/can-component-deactivate.interface';
import { DialogService } from '../../../../../shared/service/dialog.service';

@Component({
    templateUrl: 'add-scene.component.html'
})
export class AddSceneComponent implements CanComponentDeactivate {

    viewScene: SceneSummary;
    scene: SceneSummary;

    constructor(
        private _projectService: SceneService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _router: Router
    ){
        this.viewScene = new SceneSummary();
    }

    addProject() {

        let loadingId = this._loadingService.startLoading();

        this.scene = this.scene;

        this._projectService.post(this.scene).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this._router.navigate(['/projects', data]);
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    canDeactivate(){
        if(!this.scene.summary || this.viewScene.equals(this.scene))
            return true;

        return this._dialogService.confirm('All data will be lost by navigating away');
    }
}