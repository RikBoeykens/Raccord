import { EntityType } from '../../shared/enums/entity-type.enum';
import { ExcludeTypeIDs } from './exclude-type-ids.model';

export class SearchRequest{
    searchText: string;
    projectId?: number;
    includeTypes: EntityType[];
    excludeTypes: EntityType[];
    excludeTypeIDs: ExcludeTypeIDs[] = [];
}