import { BaseBreakdownType } from './base-breakdown-type.model';

export class BreakdownType extends BaseBreakdownType {
    public breakdownID: number;

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        breakdownID: number
                    }) {
        super(obj);
        if (obj) {
            this.breakdownID = obj.breakdownID;
        }
    }
}
