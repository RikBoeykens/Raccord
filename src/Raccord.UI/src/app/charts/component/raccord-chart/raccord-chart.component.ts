import { Component } from "@angular/core";
import { PageLengthHelpers } from "../../../shared/helpers/page-length.helpers";

@Component({
    templateUrl: 'raccord-chart.component.html',
    selector: "raccord-chart"
})
export class RaccordChartComponent {
    columnData = {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Completed by pagelength'
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
    areaData = {
        chart: {
            type: 'area'
        },
        title: {
            text: 'Burndown by pagelength'
        },
        xAxis: {
            categories: ["SD 1", "SD 2", "SD 3", "SD 4", "SD 5", "SD 6", "SD 6", "SD 8", "SD 9", "SD 10", "SD 11", "SD 12", "SD 13", "SD 14", "SD 15"]
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
            data: [174, 169, 152, 148, 100, 89, 72, 65, 51, 49, null, null, null, null, null]
            },
        ],
        tooltip:{
            formatter: function(){
                return PageLengthHelpers.getPageLengthString(this.y);
            }
        }
    };

    pieData={
        chart: {
            type: 'pie'
        },
        title: {
            text: 'Completed by pagelength'
        },
        tooltip: {
            formatter: function(){
                return PageLengthHelpers.getPageLengthString(this.y);
            }
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    formatter: function(){
                        return PageLengthHelpers.getPageLengthString(this.value);
                    } 
                }
            }
        },
        series: [{
            name: 'Types',
            colorByPoint: true,
            data: [{
                name: 'Not Scheduled',
                y: 32
            }, {
                name: 'Scheduled but not shot',
                y: 21
            }, {
                name: 'Shot',
                y: 45
            }]
        }]
    };
}