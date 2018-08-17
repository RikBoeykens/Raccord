import { BaseBreakdownType } from './base-breakdown-type.model';
import { BreakdownSummary, BreakdownItemSummary } from '../../../../..';

export class FullBreakdownType extends BaseBreakdownType {
    public breakdown: BreakdownSummary;
    public breakdownItems: BreakdownItemSummary[];

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        breakdown: BreakdownSummary,
                        breakdownItems: BreakdownItemSummary[],
                    }) {
        super(obj);
        if (obj) {
            this.breakdown = obj.breakdown;
            this.breakdownItems = obj.breakdownItems;
        }
    }
}
