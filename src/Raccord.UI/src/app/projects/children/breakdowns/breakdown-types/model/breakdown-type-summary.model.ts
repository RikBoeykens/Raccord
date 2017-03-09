import { BreakdownType } from './breakdown-type.model';

export class BreakdownTypeSummary extends BreakdownType{
    itemCount: number;

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        projectId: number,
                        itemCount: number,
                    }){
        super(obj);
        if(obj){
            this.itemCount = obj.itemCount;
        }
    }
}