export class ChartSeriesData {
    public name: string;
    public data: any[];

    constructor(obj?: {
        name: string,
        data: any[]
    }) {
        if (obj) {
            this.name = obj.name;
            this.data = obj.data;
        }
    }
}
