import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { FullBreakdown } from '../../model/full-breakdown.model';

@Component({
    templateUrl: 'breakdown-landing.component.html',
})
export class BreakdownLandingComponent implements OnInit {

    public breakdown: FullBreakdown;
    public project: ProjectSummary;

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            breakdown: FullBreakdown,
            project: ProjectSummary
        }) => {
            this.breakdown = data.breakdown;
            this.project = data.project;
        });
    }
}
