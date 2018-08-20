import { BaseBreakdownItem } from './base-breakdown-item.model';
import { BreakdownSummary, BreakdownType, Comment } from '../../../../..';
import { LinkedImage } from '../../../../../../shared/children/images';
import { LinkedScene } from '../../../../../../shared/children/scenes';

export class FullBreakdownItem extends BaseBreakdownItem {
    public breakdown: BreakdownSummary;
    public type: BreakdownType;
    public scenes: LinkedScene[];
    public images: LinkedImage[];
    public comments: Comment[];

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        breakdown: BreakdownSummary
                        type: BreakdownType,
                        scenes: LinkedScene[],
                        images: LinkedImage[],
                        comments: Comment[]
                    }) {
        super(obj);
        if (obj) {
            this.type = obj.type;
            this.scenes = obj.scenes;
            this.images = obj.images;
            this.comments = obj.comments;
        }
    }
}
