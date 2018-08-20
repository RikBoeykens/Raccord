import { BaseModel } from '../../../../../../shared';

export class BaseSceneComponent extends BaseModel {
    public text: string;
    public order: number;
    public type: string;

    constructor(obj?: {
                        text: string,
                        order: number,
                        type: string
                    }) {
        super();
        if (obj) {
            this.text = obj.text;
            this.order = obj.order;
            this.type = obj.type;
        }
    }
}
