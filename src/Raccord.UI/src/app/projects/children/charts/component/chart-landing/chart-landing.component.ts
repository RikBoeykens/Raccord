import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../../shared/children/projects';
import { ChartInfo } from '../../../../../charts';
import { ProjectHelpers } from '../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../shared';

@Component({
    templateUrl: 'chart-landing.component.html',
})
export class ChartLandingComponent implements OnInit {

    public project: ProjectSummary;
    public charts: ChartInfo[];

    constructor(
        private _route: ActivatedRoute
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: { charts: ChartInfo[] }) => {
            this.charts = data.charts;
        });
        this.project = ProjectHelpers.getCurrentProject();
    }

    public getBackLink() {
        return `/${RouteSettings.PROJECTS}/${this.project.id}`;
    }
}
