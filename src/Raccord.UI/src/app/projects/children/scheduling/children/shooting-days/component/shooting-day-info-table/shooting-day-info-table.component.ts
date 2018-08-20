import { Component, Input } from '@angular/core';
import { ShootingDayInfo } from '../../../../../..';
import { RouteSettings, ShootingDayTypeEnum } from '../../../../../../../shared';

@Component({
  selector: 'shooting-day-info-table',
  templateUrl: 'shooting-day-info-table.component.html',
})
export class ShootingDayInfoTableComponent {
  @Input() public shootingDays: ShootingDayInfo[];
  @Input() public projectId: number;
  public displayedColumns = [
    'unit',
    'number',
    'date'
  ];

  public getCrewUnitLink(shootingDay: ShootingDayInfo) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.CREW}/${shootingDay.crewUnit.id}`;
  }

  public getShootingDayLink(shootingDay: ShootingDayInfo): string {
    switch (shootingDay.type) {
      case ShootingDayTypeEnum.scheduled:
      case ShootingDayTypeEnum.scheduledNotOnCallsheet:
        // tslint:disable-next-line:max-line-length
        return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.SCHEDULES}/${shootingDay.crewUnit.id}`;
      case ShootingDayTypeEnum.callsheet:
      case ShootingDayTypeEnum.callsheetNotShot:
        // tslint:disable-next-line:max-line-length
        return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.CALLSHEETS}/${shootingDay.id}`;
      case ShootingDayTypeEnum.shot:
        // tslint:disable-next-line:max-line-length
        return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.SHOOTINGDAYS}/${shootingDay.id}`;
      default:
        return '/';
    }
  }
}
