import { SearchResult } from './search-result.model';
import { BaseModel } from '../../../model/base.model';

export class SearchTypeResult extends BaseModel {
    public count: number;
    public type: string;
    public results: SearchResult[];

    constructor(
        obj?: {
            count: number,
            type: string,
            results: SearchResult[]
        }
    ) {
        super();
        if (obj) {
            this.count = obj.count;
            this.type = obj.type;
            this.results = obj.results;
        }
    }
}
