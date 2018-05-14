import { BaseBreakdownType } from './base-breakdown-type.model';
import { BreakdownItemSummary } from
    '../../breakdown-items/model/breakdown-item-summary.model';
import { Breakdown } from '../../../model/breakdown.model';
import { BreakdownSummary } from '../../../model/breakdown-summary.model';

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
