import { EntityType } from '..';

export class RouteInfo {
  public type: EntityType;
  public routeIDs: any[];

  constructor(obj?: {
      type: EntityType,
      routeIDs: any[]
  }) {
      if (obj) {
          this.type = obj.type;
          this.routeIDs = obj.routeIDs;
      }
  }
}
