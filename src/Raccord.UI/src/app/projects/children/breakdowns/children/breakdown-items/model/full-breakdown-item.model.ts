import { LinkedScene } from '../../../../scenes/model/linked-scene.model';
import { LinkedImage } from '../../../../images/model/linked-image.model';
import { BreakdownType } from '../../breakdown-types/model/breakdown-type.model';
import { BaseBreakdownItem } from './base-breakdown-item.model';
import { Breakdown } from '../../../model/breakdown.model';
import { BreakdownSummary } from '../../../model/breakdown-summary.model';

export class FullBreakdownItem extends BaseBreakdownItem {
    public breakdown: BreakdownSummary;
    public type: BreakdownType;
    public scenes: LinkedScene[];
    public images: LinkedImage[];

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        breakdown: BreakdownSummary
                        type: BreakdownType,
                        scenes: LinkedScene[],
                        images: LinkedImage[]
                    }) {
        super(obj);
        if (obj) {
            this.type = obj.type;
            this.scenes = obj.scenes;
            this.images = obj.images;
        }
    }
}
