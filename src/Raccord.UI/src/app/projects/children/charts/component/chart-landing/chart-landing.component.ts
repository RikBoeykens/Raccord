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
    columnObjectData = new ChartInfo({
        title: "Pagelength by day",
        chartType: ChartType.column,
        dataType: ChartDataType.pagelength,
        baseData: ["SD 1", "SD 2", "SD 3", "SD 4", "SD 5", "SD 6", "SD 6", "SD 8", "SD 9", "SD 10", "SD 11", "SD 12", "SD 13", "SD 14", "SD 15"],
        seriesData: [{name:"Pagelength", data:[23, 69, 22, 48, 10, 76, 64, 65, 50, 49, null, null, null, null, null]}],
    });
    areaObjectData = new ChartInfo({
        title: "Burndown by pagelength",
        chartType: ChartType.area,
        dataType: ChartDataType.pagelength,
        baseData: ["SD 1", "SD 2", "SD 3", "SD 4", "SD 5", "SD 6", "SD 6", "SD 8", "SD 9", "SD 10", "SD 11", "SD 12", "SD 13", "SD 14", "SD 15"],
        seriesData: [{name:"Burndown", data:[174, 169, 152, 148, 100, 89, 72, 65, 51, 49, null, null, null, null, null]}],
    });
    pieObjectData = new ChartInfo({
        title: "Completed by pagelength",
        chartType: ChartType.pie,
        dataType: ChartDataType.pagelength,
        baseData: ["Not Scheduled", "Scheduled but not shot", "Shot"],
        seriesData: [{name:"", data:[32, 21, 45]}],
    });

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