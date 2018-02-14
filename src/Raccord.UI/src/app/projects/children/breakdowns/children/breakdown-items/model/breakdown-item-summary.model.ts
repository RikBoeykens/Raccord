import { BreakdownItem } from './breakdown-item.model';
import { Image } from '../../../../images/model/image.model';
import { BreakdownType } from '../../breakdown-types/model/breakdown-type.model';

export class BreakdownItemSummary extends BreakdownItem {
    public sceneCount: number;
    public primaryImage: Image;

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        breakdownID: number,
                        breakdownTypeID: number,
                        sceneCount: number,
                        primaryImage: Image
                    }) {
        super(obj);
        if (obj) {
            this.sceneCount = obj.sceneCount;
            this.primaryImage = obj.primaryImage;
        }
    }
}
