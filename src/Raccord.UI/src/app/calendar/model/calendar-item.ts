import { BaseModel } from '../../shared';
import { RouteInfo } from '../../shared/model/route-info.model';

export class CalendarItem extends BaseModel {
  public date: Date;
  public label: string;
  public routeInfo: RouteInfo;

  constructor(obj?: {
                      date: Date,
                      label: string,
                      routeInfo: RouteInfo
                  }) {
      super();
      if (obj) {
          this.date = obj.date;
          this.label = obj.label;
          this.routeInfo = obj.routeInfo;
      }
  }
}
