import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FullScheduleDay } from '../../schedule-days/model/full-schedule-day.model';
import { ProjectSummary } from '../../../../model/project-summary.model';

@Component({
    templateUrl: 'schedule-landing.component.html',
})
export class ScheduleLandingComponent extends OnInit {

    scheduleDays: FullScheduleDay[] = [];
    project: ProjectSummary;

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
        super();
    }

    ngOnInit() {
        this._route.data.subscribe((data: { scheduleDays: FullScheduleDay[], project: ProjectSummary }) => {
            this.scheduleDays = data.scheduleDays;
            this.project = data.project;
        });
    }
}