import {
    BaseBreakdownType
} from '../../../../../../breakdowns/children/types/model/base-breakdown-type.model';
import { CallsheetBreakdownItemScene } from '../../../../../../..';

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
