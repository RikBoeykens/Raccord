import { EntityType } from '../enums/entity-type.enum';

export class SelectedEntity{
    entityId: number;
    type: EntityType;

    constructor(obj?: {entityId: number, type: EntityType}){
        if(obj){
            this.entityId = obj.entityId;
            this.type = obj.type;
        }
    }
}