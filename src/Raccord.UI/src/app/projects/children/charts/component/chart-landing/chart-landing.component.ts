import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { Ng2Highcharts } from 'ng2-highcharts/ng2-highcharts';
import { PageLengthHelpers } from "../../../../../shared/helpers/page-length.helpers";

@Component({
    templateUrl: 'chart-landing.component.html',
})
export class ChartLandingComponent {

    project: ProjectSummary;  
    chartData = {
        chart: {
            type: 'column'
        },
        xAxis: {
            categories: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
        },
        yAxis:{
            labels:{
                formatter: function(){
                    return PageLengthHelpers.getPageLengthString(this.value);
                }
            }
        },
        series: [
            {
            name: 'Page lengths',
            data: [4, 9, 12, 3, 6, 7, 5, 8, 31, 14, 2]
            },
        ],
        tooltip:{
            formatter: function(){
                return PageLengthHelpers.getPageLengthString(this.y);
            }
        }
    };

    constructor(
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary }) => {
            this.project = data.project;
        });
    }
}