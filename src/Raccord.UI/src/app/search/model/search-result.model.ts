import { EntityType } from '../../shared/enums/entity-type.enum';

export class SearchResult{
    id: number;
    routeIDs: number[];
    displayName: string;
    info: string;
    type: EntityType;
}