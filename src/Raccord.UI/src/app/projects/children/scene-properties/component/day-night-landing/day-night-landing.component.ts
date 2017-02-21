import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DayNightHttpService } from '../../service/day-night-http.service';
import { FullDayNight } from '../../model/full-day-night.model';
import { ProjectSummary } from '../../../../model/project-summary.model';

@Component({
    templateUrl: 'day-night-landing.component.html',
})
export class DayNightLandingComponent {

    dayNight: FullDayNight;
    project: ProjectSummary;

    constructor(
        private _dayNightHttpService: DayNightHttpService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { dayNight: FullDayNight, project: ProjectSummary }) => {
            this.dayNight = data.dayNight;
            this.project = data.project;
        });
    }
}