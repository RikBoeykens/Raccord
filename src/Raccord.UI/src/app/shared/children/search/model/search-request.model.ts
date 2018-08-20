import { ExcludeTypeIDs } from './exclude-type-ids.model';
import { BaseModel } from '../../../model/base.model';
import { EntityType } from '../../..';

export class SearchRequest extends BaseModel {
    public searchText: string;
    public projectId?: number;
    public includeTypes: EntityType[];
    public excludeTypes: EntityType[];
    public excludeTypeIDs: ExcludeTypeIDs[] = [];

    constructor(
        obj?: {
            searchText: string,
            projectId?: number,
            includeTypes: EntityType[],
            excludeTypes: EntityType[],
            excludeTypeIDs: ExcludeTypeIDs[]
        }
    ) {
        super();
        if (obj) {
            this.searchText = obj.searchText;
            this.projectId = obj.projectId;
            this.includeTypes = obj.includeTypes;
            this.excludeTypes = obj.excludeTypes;
            this.excludeTypeIDs = obj.excludeTypeIDs;
        }
    }
}
