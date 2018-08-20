import { EntityType } from '../../..';
import { BaseModel } from '../../../model/base.model';

export class ExcludeTypeIDs extends BaseModel {
    public type: EntityType;
    public ids: any[] = [];

    constructor(
        obj?: {
            type: EntityType,
            ids: any[]
        }
    ) {
        super();
        if (obj) {
            this.type = obj.type;
            this.ids = obj.ids;
        }
    }
}
