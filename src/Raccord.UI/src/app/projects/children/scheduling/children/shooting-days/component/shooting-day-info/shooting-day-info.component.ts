import { Component, Input } from '@angular/core';
import { ShootingDayInfo } from '../../../../../..';
import { ShootingDayTypeEnum } from '../../../../../../../shared';

@Component({
  selector: 'shooting-day-info',
  templateUrl: 'shooting-day-info.component.html',
})
export class ShootingDayInfoComponent {
  @Input() public shootingDays: ShootingDayInfo[];
  @Input() public projectId: number;

  public filterShootingDays(type: ShootingDayTypeEnum) {
    return this.shootingDays.filter((shootingDay: ShootingDayInfo) => shootingDay.type === type);
  }

  public getScheduledAvailable() {
    return this.getScheduledShootingDays().length;
  }

  public getScheduledShootingDays() {
      return this.filterShootingDays(ShootingDayTypeEnum.scheduled);
  }

  public getScheduledNotCallsheetAvailable() {
    return this.getScheduledNotCallsheetShootingDays().length;
  }

  public getScheduledNotCallsheetShootingDays() {
    return this.filterShootingDays(ShootingDayTypeEnum.scheduledNotOnCallsheet);
  }

  public getCallsheetAvailable() {
    return this.getCallsheetShootingDays().length;
  }

  public getCallsheetShootingDays() {
    return this.filterShootingDays(ShootingDayTypeEnum.callsheet);
  }

  public getCallsheetNotShotAvailable() {
    return this.getCallsheetNotShotShootingDays().length;
  }

  public getCallsheetNotShotShootingDays() {
    return this.filterShootingDays(ShootingDayTypeEnum.callsheetNotShot);
  }

  public getShotAvailable() {
    return this.getShotShootingDays().length;
  }

  public getShotShootingDays() {
    return this.filterShootingDays(ShootingDayTypeEnum.shot);
  }
}
