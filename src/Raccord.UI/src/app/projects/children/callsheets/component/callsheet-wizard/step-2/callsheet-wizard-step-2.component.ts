import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CallsheetSceneHttpService } from "../../../children/callsheet-scenes/service/callsheet-scene-http.service";
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { FullCallsheet } from "../../../";
import { CallsheetScene } from "../../../";
import { CallsheetSceneScene } from "../../../";

@Component({
    templateUrl: 'callsheet-wizard-step-2.component.html',
})
export class CallsheetWizardStep2Component implements OnInit {

    project: ProjectSummary;
    callsheet: FullCallsheet;

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
        private _callsheetSceneHttpService: CallsheetSceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, callsheet: FullCallsheet }) => {
            this.project = data.project;
            this.callsheet = data.callsheet;
        });
    }
}