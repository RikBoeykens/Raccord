import { EntityType } from '../../shared/enums/entity-type.enum';

export class ExcludeTypeIDs{
    public type: EntityType;
    public ids: number[] = [];
}