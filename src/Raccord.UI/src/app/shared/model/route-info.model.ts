import { EntityType } from '../enums/entity-type.enum';

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
