import { BaseBreakdownItem } from './base-breakdown-item.model';

export class BreakdownItem extends BaseBreakdownItem {
    public breakdownID: number;
    public breakdownTypeID: number;

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        breakdownID: number,
                        breakdownTypeID: number
                    }) {
        super(obj);
        if (obj) {
            this.breakdownID = obj.breakdownID;
            this.breakdownTypeID = obj.breakdownTypeID;
        }
    }
}
