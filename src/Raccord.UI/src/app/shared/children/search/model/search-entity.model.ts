import { BaseModel } from '../../../model/base.model';

export class SearchEntity extends BaseModel {
    public id: any;
    public name: string;

    constructor(
        obj?: {
            id: any,
            name: string
        }
    ) {
        super();
        if (obj) {
            this.id = obj.id;
            this.name = obj.name;
        }
    }
}
