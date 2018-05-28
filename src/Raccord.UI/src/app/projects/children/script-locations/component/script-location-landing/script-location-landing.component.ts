import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ScriptLocationHttpService } from '../../service/script-location-http.service';
import { FullScriptLocation } from '../../model/full-script-location.model';
import { ScriptLocation } from '../../model/script-location.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from '../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';

@Component({
    templateUrl: 'script-location-landing.component.html',
})
export class ScriptLocationLandingComponent {

    scriptLocation: FullScriptLocation;
    viewScriptLocation: ScriptLocation;
    project: ProjectSummary;

    constructor(
        private _scriptLocationHttpService: ScriptLocationHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: {
            scriptLocation: FullScriptLocation,
            project: ProjectSummary
        }) => {
            this.scriptLocation = data.scriptLocation;
            this.viewScriptLocation = new ScriptLocation(data.scriptLocation);
            this.project = data.project;
        });
    }

    getScriptLocation(){
        this._loadingWrapperService.Load(
            this._scriptLocationHttpService.get(this.scriptLocation.id),
            (data) => {
                this.scriptLocation = data;
                this.viewScriptLocation = new ScriptLocation(data);
            }
        );
    }

    updateScriptLocation() {
        this._loadingWrapperService.Load(
            this._scriptLocationHttpService.post(this.viewScriptLocation),
            () => this.getScriptLocation()
        );
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canEditGeneral
        );
    }
}