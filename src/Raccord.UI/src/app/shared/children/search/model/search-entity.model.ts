import { BaseModel } from '../../../model/base.model';

export class SearchEntity extends BaseModel {
    public id: number;
    public name: string;

    constructor(
        obj?: {
            id: number,
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
