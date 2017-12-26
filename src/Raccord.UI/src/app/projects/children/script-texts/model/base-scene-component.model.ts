import { BaseModel } from '../../../../shared/model/base.model';

export class BaseSceneComponent extends BaseModel {
    text: string;
    order: number;
    type: string;

    constructor(obj?: {
                        text: string,
                        order: number,
                        type: string
                    }){
        super();
        if(obj){
            this.text = obj.text;
            this.order = obj.order;
            this.type = obj.type;
        }
    }
}