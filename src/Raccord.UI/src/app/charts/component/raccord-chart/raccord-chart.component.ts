import { Component, OnInit, Input } from '@angular/core';
import { Ng2Highcharts } from 'ng2-highcharts';
import * as Highcharts from 'highcharts';
window['Highcharts'] = Highcharts;
import { ChartInfo, ChartType, ChartSeriesData, ChartDataType } from '../..';
import { TimespanHelpers } from '../../../shared/helpers/timespan.helpers';
import { PageLengthHelpers } from '../../../shared/helpers/page-length.helpers';

@Component({
    templateUrl: 'raccord-chart.component.html',
    selector: 'raccord-chart'
})
export class RaccordChartComponent implements OnInit {
    @Input() public chartObjectData: ChartInfo;
    public chartData: any;

    public ngOnInit() {
        this.chartData = this.getChartData();
    }

    private getChartData() {
        return this.parseChartInfo(this.chartObjectData);
    }

    private parseChartInfo(chartInfo: ChartInfo) {
        return this.getChartType(chartInfo);
    }

    private getChartType(chartInfo: ChartInfo) {
        switch (chartInfo.chartType) {
            case ChartType.pie: {
                return this.getPieData(chartInfo);
            }
            case ChartType.area: {
                return this.getAreaOrColumnData(chartInfo, 'area');
            }
            case ChartType.column: {
                return this.getAreaOrColumnData(chartInfo, 'column');
            }
        }
    }

    private getAreaOrColumnData(chartInfo: ChartInfo, chartType: string) {
        return {
            title: {
                text: chartInfo.title
            },
            chart: {
                type: chartType
            },
            tooltip: {
                formatter: this.getTooltipFormatter(chartInfo.dataType),
            },
            xAxis: {
                categories: chartInfo.baseData
            },
            yAxis: {
                labels: {
                    formatter: this.getYaxisLabelFormatter(chartInfo.dataType)
                }
            },
            series: chartInfo.seriesData.map((seriesData: ChartSeriesData) => {
                return {
                    name: seriesData.name,
                    data: seriesData.data.map((dataPoint) => {
                        if (chartInfo.dataType === ChartDataType.timespan) {
                            dataPoint = dataPoint ?
                                TimespanHelpers.getTimespanNumber(dataPoint) : null;
                        }
                        return dataPoint;
                    })
                };
            }),
        };
    }

    private getPieData(chartInfo: ChartInfo) {
        const pieSeriesData = [];
        for (let i = 0; i < chartInfo.baseData.length; i++) {
            let seriesDataPoint = chartInfo.seriesData[0].data[i];
            if (chartInfo.dataType === ChartDataType.timespan) {
                seriesDataPoint = TimespanHelpers.getTimespanNumber(seriesDataPoint);
            }
            pieSeriesData.push({name: chartInfo.baseData[i], y: seriesDataPoint});
        }

        return {
            title: {
                text: chartInfo.title
            },
            chart: {
                type: 'pie'
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

    private getTooltipFormatter(dataType: ChartDataType) {
        switch (dataType) {
            case ChartDataType.number: {
                return tooltipNumberFormatter;
            }
            case ChartDataType.pagelength: {
                return tooltipPageLengthFormatter;
            }
            case ChartDataType.timespan: {
                return tooltipTimespanFormatter;
            }
        }
    }

    private getYaxisLabelFormatter(dataType: ChartDataType) {
        switch (dataType) {
            case ChartDataType.number: {
                return yAxisLabelNumberFormatter;
            }
            case ChartDataType.pagelength: {
                return yAxisLabelPageLengthFormatter;
            }
            case ChartDataType.timespan: {
                return yAxisLabelTimespanFormatter;
            }
        }
    }
}

function tooltipNumberFormatter() {
    return this.y;
}

function tooltipPageLengthFormatter() {
    return PageLengthHelpers.getPageLengthString(this.y);
}

function tooltipTimespanFormatter() {
    return TimespanHelpers.getTimespanString(this.y);
}

function yAxisLabelNumberFormatter() {
    return this.value;
}

function yAxisLabelPageLengthFormatter() {
    return PageLengthHelpers.getPageLengthString(this.value);
}

function yAxisLabelTimespanFormatter() {
    return TimespanHelpers.getTimespanString(this.value);
}
