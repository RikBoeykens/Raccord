import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { Ng2Highcharts } from 'ng2-highcharts/ng2-highcharts';
import { PageLengthHelpers } from "../../../../../shared/helpers/page-length.helpers";
import { ChartInfo } from "../../../../../charts/model/chart-info.model";
import { ChartType } from "../../../../../charts/enum/chart-type.enum";
import { ChartDataType } from "../../../../../charts/enum/chart-data-type.enum";

@Component({
    templateUrl: 'chart-landing.component.html',
})
export class ChartLandingComponent {

    project: ProjectSummary;
    charts: ChartInfo[];

    constructor(
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, charts: ChartInfo[] }) => {
            this.project = data.project;
            this.charts = data.charts;
        });
    }
}