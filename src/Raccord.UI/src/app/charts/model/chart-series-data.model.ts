export class ChartSeriesData{
    name: string;
    data: any[];

    constructor(obj?:{
        name: string,
        data: any[]
    }){
        if(obj){
            this.name = obj.name;
            this.data = obj.data;
        }
    }
}