import { SearchType } from '../../shared/enums/search-type.enum';

export class SearchRequest{
    searchText: string;
    projectId?: number;
    includeTypes: SearchType[];
    excludeTypes: SearchType[];
}