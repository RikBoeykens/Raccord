import { Component, OnInit, Input } from "@angular/core";
import { PageLengthHelpers } from "../../../shared/helpers/page-length.helpers";
import { ChartType } from "../../enum/chart-type.enum";
import { ChartInfo } from "../../model/chart-info.model";
import { ChartDataType } from "../../enum/chart-data-type.enum";
import { TimespanHelpers } from "../../../shared/helpers/timespan.helpers";
import { ChartSeriesData } from "../../model/chart-series-data.model";

@Component({
    templateUrl: 'raccord-chart.component.html',
    selector: "raccord-chart"
})
export class RaccordChartComponent implements OnInit {
    @Input() chartObjectData: ChartInfo;
    chartData: any;

    ngOnInit(){
        this.chartData = this.getChartData();
    }

    getChartData(){
        return this.parseChartInfo(this.chartObjectData);
    }

    parseChartInfo(chartInfo: ChartInfo){
        return this.getChartType(chartInfo);
    }

    getChartType(chartInfo: ChartInfo){
        switch(chartInfo.chartType){
            case ChartType.pie:{
                return this.getPieData(chartInfo);
            }
            case ChartType.area:{
                return this.getAreaOrColumnData(chartInfo, "area");
            }
            case ChartType.column:{
                return this.getAreaOrColumnData(chartInfo, "column");
            }
        }
    }
    
    getAreaOrColumnData(chartInfo: ChartInfo, type: string){
        return {
            title:{
                text: chartInfo.title
            },
            chart: {
                type: type
            },
            tooltip: {
                formatter: this.getTooltipFormatter(chartInfo.dataType),
            },
            xAxis: {
                categories: chartInfo.baseData
            },
            yAxis:{
                labels:{
                    formatter: this.getYaxisLabelFormatter(chartInfo.dataType)
                }
            },
            series: chartInfo.seriesData.map((seriesData: ChartSeriesData)=>{
                return {
                    name: seriesData.name, 
                    data: seriesData.data.map((dataPoint)=>{
                        if(chartInfo.dataType===ChartDataType.timespan){
                            dataPoint = TimespanHelpers.getTimespanNumber(dataPoint);
                        }
                        return dataPoint;
                    })
                };
            }),
        };
    }

    getPieData(chartInfo: ChartInfo){
        let pieSeriesData= [];
        for(let i =0; i< chartInfo.baseData.length; i++){
            let seriesDataPoint = chartInfo.seriesData[0].data[i];
            if(chartInfo.dataType===ChartDataType.timespan){
                seriesDataPoint = TimespanHelpers.getTimespanNumber(seriesDataPoint);
            }
            pieSeriesData.push({name: chartInfo.baseData[i], y: seriesDataPoint});
        }

        return {
            title:{
                text: chartInfo.title
            },
            chart: {
                type: "pie"
            },        
            series: [{
                colorByPoint: true,
                data: pieSeriesData
            }],
            tooltip: {
                formatter: this.getTooltipFormatter(chartInfo.dataType),
            },
        };
    }

    getTooltipFormatter(dataType: ChartDataType){
        switch(dataType){
            case ChartDataType.number:{
                return tooltipNumberFormatter;
            }
            case ChartDataType.pagelength:{
                return tooltipPageLengthFormatter;
            }
            case ChartDataType.timespan:{
                return tooltipTimespanFormatter;
            }
        }
    }

    getYaxisLabelFormatter(dataType: ChartDataType){
        switch(dataType){
            case ChartDataType.number:{
                return yAxisLabelNumberFormatter;
            }
            case ChartDataType.pagelength:{
                return yAxisLabelPageLengthFormatter;
            }
            case ChartDataType.timespan:{
                return yAxisLabelTimespanFormatter;
            }
        }
    }
}

function tooltipNumberFormatter(){
    return this.y;
}

function tooltipPageLengthFormatter(){
    return PageLengthHelpers.getPageLengthString(this.y);
}

function tooltipTimespanFormatter(){
    return TimespanHelpers.getTimespanString(this.y);
}


function yAxisLabelNumberFormatter(){
    return this.value;
}

function yAxisLabelPageLengthFormatter(){
    return PageLengthHelpers.getPageLengthString(this.value);
}

function yAxisLabelTimespanFormatter(){
    return TimespanHelpers.getTimespanString(this.value);
}