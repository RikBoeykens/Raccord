import { BaseShootingDay } from './base-shooting-day.model';

export class ShootingDay extends BaseShootingDay {
  public crewUnitID: number;

  constructor(obj?: {
                      id: number,
                      number: string,
                      date: Date,
                      start: Date,
                      turn: Date,
                      end: Date,
                      overTime: string,
                      completed: boolean,
                      scheduleDayID?: number,
                      callsheetID?: number,
                      crewUnitID: number
                  }) {
      super(obj);
      if (obj) {
          this.crewUnitID = obj.crewUnitID;
      }
  }
}
