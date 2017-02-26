import { EntityType } from '../../shared/enums/entity-type.enum';

export class SearchRequest{
    searchText: string;
    projectId?: number;
    includeTypes: EntityType[];
    excludeTypes: EntityType[];
}