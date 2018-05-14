import { BaseModel } from '../../shared/model/base.model';

export class Project extends BaseModel {
    public id: number;
    public title: string;

    constructor(obj?: {id: number, title: string}) {
        super();
        if (obj) {
            this.id = obj.id;
            this.title = obj.title;
        }
    }
}