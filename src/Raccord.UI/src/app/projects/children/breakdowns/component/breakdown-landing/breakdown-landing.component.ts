import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BreakdownTypeSummary } from '../../breakdown-types/model/breakdown-type-summary.model';
import { ProjectSummary } from '../../../../model/project-summary.model';

@Component({
    templateUrl: 'breakdown-landing.component.html',
})
export class BreakdownLandingComponent extends OnInit {

    breakdownTypes: BreakdownTypeSummary[] = [];
    project: ProjectSummary;

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
        super();
    }

    ngOnInit() {
        this._route.data.subscribe((data: { breakdownTypes: BreakdownTypeSummary[], project: ProjectSummary }) => {
            this.breakdownTypes = data.breakdownTypes;
            this.project = data.project;
        });
    }
}