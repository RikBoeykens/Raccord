import { Component, Input } from '@angular/core';
import { ShootingDayInfoSceneCollection } from '../../../../../..';
import { RouteSettings, ShootingDayTypeEnum } from '../../../../../../../shared';
import { SceneSummary } from '../../../../../../../shared/children/scenes';

@Component({
  selector: 'shooting-day-info-scenes-table',
  templateUrl: 'shooting-day-info-scenes-table.component.html',
})
export class ShootingDayInfoScenesTableComponent {
  @Input() public shootingDays: ShootingDayInfoSceneCollection[];
  @Input() public projectId: number;
  public displayedColumns = [
    'unit',
    'number',
    'date',
    'scenes'
  ];

  public getCrewUnitLink(shootingDay: ShootingDayInfoSceneCollection) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.UNITS}/${shootingDay.crewUnit.id}`;
  }

  public getSceneLink(scene: SceneSummary) {
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.SCENES}/${scene.id}`;
  }

  public getShootingDayLink(shootingDay: ShootingDayInfoSceneCollection): string {
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
