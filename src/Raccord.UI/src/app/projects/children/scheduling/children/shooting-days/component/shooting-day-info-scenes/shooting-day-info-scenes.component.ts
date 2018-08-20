import { Component, Input } from '@angular/core';
import { ShootingDayInfoSceneCollection } from '../../../../../..';
import { ShootingDayTypeEnum } from '../../../../../../../shared';

@Component({
  selector: 'shooting-day-info-scenes',
  templateUrl: 'shooting-day-info-scenes.component.html',
})
export class ShootingDayInfoScenesComponent {
  @Input() public shootingDays: ShootingDayInfoSceneCollection[];
  @Input() public projectId: number;

  public filterShootingDays(type: ShootingDayTypeEnum) {
    return this.shootingDays.filter(
        (shootingDay: ShootingDayInfoSceneCollection) => shootingDay.type === type);
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
