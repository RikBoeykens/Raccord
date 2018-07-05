import { BaseModel } from '../../../model/base.model';
import { EntityType } from '../../..';
import { RouteInfo } from '../../../model/route-info.model';

export class SearchResult extends BaseModel {
    public id: number;
    public displayName: string;
    public info: string;
    public routeInfo: RouteInfo;

    constructor(
        obj?: {
            id: number,
            displayName: string,
            info: string;
            routeInfo: RouteInfo
        }
    ) {
        super();
        if (obj) {
            this.id = obj.id;
            this.displayName = obj.displayName;
            this.info = obj.info;
            this.routeInfo = obj.routeInfo;
        }
    }
}
