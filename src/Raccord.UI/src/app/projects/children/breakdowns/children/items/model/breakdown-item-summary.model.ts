import { BreakdownItem } from './breakdown-item.model';
import { Image } from '../../../../../../shared/children/images';

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
