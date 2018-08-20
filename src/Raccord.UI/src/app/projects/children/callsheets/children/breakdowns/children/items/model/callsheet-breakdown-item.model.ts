import {
    BaseBreakdownItem
} from '../../../../../../breakdowns/children/items/model/base-breakdown-item.model';

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
