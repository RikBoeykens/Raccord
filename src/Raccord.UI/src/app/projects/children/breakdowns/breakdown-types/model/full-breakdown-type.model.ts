import { BreakdownType } from './breakdown-type.model';
import { BreakdownItemSummary } from '../../../breakdowns/breakdown-items/model/breakdown-item-summary.model'

export class FullBreakdownType extends BreakdownType{
    breakdownItems: BreakdownItemSummary[];

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        projectId: number,
                        breakdownItems: BreakdownItemSummary[],
                    }){
        super(obj);
        if(obj){
            this.breakdownItems = obj.breakdownItems;
        }
    }
}