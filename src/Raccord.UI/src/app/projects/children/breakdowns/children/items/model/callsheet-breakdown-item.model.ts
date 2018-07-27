import { BaseBreakdownItem } from './base-breakdown-item.model';

export class CallsheetBreakdownItem extends BaseBreakdownItem {
    constructor(
        obj?: {
            id: number,
            name: string,
            description: string
    }) {
        super(obj);
    }
}
