import { ChartType } from "../enum/chart-type.enum";
import { ChartDataType } from "../enum/chart-data-type.enum";
import { ChartSeriesData } from "./chart-series-data.model";

export class ChartInfo {
    title: string;
    chartType: ChartType;
    dataType: ChartDataType;
    baseData: any[];
    seriesData: ChartSeriesData[];

    constructor(obj?:{
        title: string,
        chartType: ChartType,
        dataType: ChartDataType,
        baseData: any[],
        seriesData: ChartSeriesData[]
    }){
        if(obj){
            this.title = obj.title;
            this.chartType = obj.chartType;
            this.dataType = obj.dataType;
            this.baseData = obj.baseData;
            this.seriesData = obj.seriesData;
        }
    }
}