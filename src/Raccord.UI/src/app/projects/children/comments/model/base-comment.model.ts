import { BaseModel } from '../../../../shared/model/base.model';

export class BaseComment extends BaseModel {
    public id: number;
    public text: string;

    constructor(obj?: {
                        id: number,
                        text: string
                    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.text = obj.text;
        } else {
            this.id = 0;
        }
    }
}
