import { ChartType, ChartDataType, ChartSeriesData } from '..';

export class ChartInfo {
    public title: string;
    public chartType: ChartType;
    public dataType: ChartDataType;
    public chartWidth: number;
    public baseData: any[];
    public seriesData: ChartSeriesData[];

    constructor(obj?: {
        title: string,
        chartType: ChartType,
        dataType: ChartDataType,
        chartWidth: number,
        baseData: any[],
        seriesData: ChartSeriesData[]
    }) {
        if (obj) {
            this.title = obj.title;
            this.chartType = obj.chartType;
            this.dataType = obj.dataType;
            this.chartWidth = obj.chartWidth;
            this.baseData = obj.baseData;
            this.seriesData = obj.seriesData;
        }
    }
}
