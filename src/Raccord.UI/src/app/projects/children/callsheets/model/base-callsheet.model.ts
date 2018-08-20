import { BaseModel } from '../../../../shared';
import { ShootingDay } from '../../..';

export class BaseCallsheet extends BaseModel {
  public id: number;
  public start: Date;
  public end: Date;
  public crewCall: Date;
  public shootingDay: ShootingDay;

  constructor(obj?: {
                      id: number,
                      start: Date,
                      end: Date,
                      crewCall: Date,
                      shootingDay: ShootingDay,
                  }) {
      super();
      if (obj) {
          this.id = obj.id;
          this.start = obj.start;
          this.end = obj.end;
          this.crewCall = obj.crewCall;
          this.shootingDay = obj.shootingDay;
      } else {
          this.id = 0;
      }
  }
}
