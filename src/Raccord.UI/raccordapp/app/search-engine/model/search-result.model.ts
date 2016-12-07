import { SearchType } from '../../shared/enums/search-type.enum';

export class SearchResult{
    routeIDs: number[];
    displayName: string;
    info: string;
    type: SearchType;
}