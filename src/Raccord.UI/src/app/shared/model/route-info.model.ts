import { EntityType } from '..';

export class RouteInfo {
  public type: EntityType;
  public routeIDs: number[];

  constructor(obj?: {
      type: EntityType,
      routeIDs: number[]
  }) {
      if (obj) {
          this.type = obj.type;
          this.routeIDs = obj.routeIDs;
      }
  }
}
