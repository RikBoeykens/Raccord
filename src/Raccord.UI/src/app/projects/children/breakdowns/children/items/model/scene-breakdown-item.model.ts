import { BaseBreakdownItem } from './base-breakdown-item.model';
import { Image } from '../../../../../../shared/children/images';
import { BreakdownType } from '../../../../..';

export class SceneBreakdownItem extends BaseBreakdownItem {
    public linkID: number;
    public type: BreakdownType;
    public primaryImage: Image;

    constructor(obj?: {
                    id: number,
                    name: string,
                    description: string,
                    linkID: number,
                    type: BreakdownType,
                    primaryImage: Image
                    }) {
        super(obj);
        if (obj) {
            this.linkID = obj.linkID;
            this.type = obj.type;
            this.primaryImage = obj.primaryImage;
        }
    }
}
