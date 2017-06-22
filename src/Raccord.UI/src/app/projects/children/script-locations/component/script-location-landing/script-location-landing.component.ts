import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ScriptLocationHttpService } from '../../service/script-location-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { FullScriptLocation } from '../../model/full-script-location.model';
import { ScriptLocation } from '../../model/script-location.model';
import { ProjectSummary } from '../../../../model/project-summary.model';

@Component({
    templateUrl: 'script-location-landing.component.html',
})
export class ScriptLocationLandingComponent {

    scriptLocation: FullScriptLocation;
    viewScriptLocation: ScriptLocation;
    project: ProjectSummary;

    constructor(
        private _scriptLocationHttpService: ScriptLocationHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { scriptLocation: FullScriptLocation, project: ProjectSummary }) => {
            this.scriptLocation = data.scriptLocation;
            this.viewScriptLocation = new ScriptLocation(data.scriptLocation);
            this.project = data.project;
        });
    }

    getScriptLocation(){
        let loadingId = this._loadingService.startLoading();

        this._scriptLocationHttpService.get(this.scriptLocation.id).then(data => {
            this.scriptLocation = data;
            this.viewScriptLocation = new ScriptLocation(data);
            this._loadingService.endLoading(loadingId);
        });
    }

    updateScriptLocation(){
        let loadingId = this._loadingService.startLoading();

        this._scriptLocationHttpService.post(this.viewScriptLocation).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScriptLocation();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}