import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ScriptLocationHttpService } from '../../service/script-location-http.service';
import { ScriptLocationSummary } from '../../model/script-location-summary.model';
import { ScriptLocation } from '../../model/script-location.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../shared/helpers/html-class.helpers';

@Component({
    templateUrl: 'script-locations-list.component.html',
})
export class ScriptLocationsListComponent implements OnInit {

    scriptLocations: ScriptLocationSummary[] = [];
    project: ProjectSummary;

    constructor(
        private _scriptLocationHttpService: ScriptLocationHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { scriptLocations: ScriptLocationSummary[], project: ProjectSummary }) => {
            this.scriptLocations = data.scriptLocations;
            this.project = data.project;
        });
    }
}