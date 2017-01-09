import { SearchType } from '../../shared/enums/search-type.enum';

export class SearchResult{
    id: number;
    routeIDs: number[];
    displayName: string;
    info: string;
    type: SearchType;
}