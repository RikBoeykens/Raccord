import { CallsheetBreakdownItemScene } from
    '../../breakdown-item-scenes/model/callsheet-breakdown-item-scene.model';
import { BaseBreakdownType } from './base-breakdown-type.model';

export class CallsheetBreakdownType extends BaseBreakdownType {
    public scenes: CallsheetBreakdownItemScene[];
    public hasItems: boolean;

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        scenes: CallsheetBreakdownItemScene[],
                        hasItems: boolean;
                    }) {
        super(obj);
        if (obj) {
            this.scenes = obj.scenes;
            this.hasItems = obj.hasItems;
        }
    }
}
