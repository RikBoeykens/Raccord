import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../model/project-summary.model';

@Component({
    templateUrl: 'callsheet-landing.component.html',
})
export class CallsheetLandingComponent implements OnInit {

    project: ProjectSummary;

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary }) => {
            this.project = data.project;
        });
    }
}