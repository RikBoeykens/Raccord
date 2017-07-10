import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { FullCallsheet } from "../../../";

@Component({
    templateUrl: 'callsheet-wizard-step-1.component.html',
})
export class CallsheetWizardStep1Component implements OnInit {

    project: ProjectSummary;
    callsheet: FullCallsheet;

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, callsheet: FullCallsheet }) => {
            this.project = data.project;
            this.callsheet = data.callsheet;
        });
    }
}