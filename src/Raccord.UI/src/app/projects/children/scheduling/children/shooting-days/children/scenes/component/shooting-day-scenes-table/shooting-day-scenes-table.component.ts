import { Component, Input, OnInit } from '@angular/core';
import { ShootingDaySceneScene } from '../../../../../../../..';
import { RouteSettings } from '../../../../../../../../../shared';

@Component({
  selector: 'shooting-day-scenes-table',
  templateUrl: 'shooting-day-scenes-table.component.html',
})
export class ShootingDayScenesTableComponent implements OnInit {
  @Input() public shootingDayScenes: ShootingDaySceneScene[];
  @Input() public shootingDayScenesWithTotalRow: ShootingDaySceneScene[];
  @Input() public projectId: number;
  public displayedColumns = [
    'scene',
    'tpl',
    'ppl',
    'cpl',
    'rpl'
  ];

  public ngOnInit() {
    this.shootingDayScenesWithTotalRow =
      this.shootingDayScenes.map((shootingDayScene) => shootingDayScene);
    this.appendTotalRow();
  }

  public getSceneLink(shootingDayScene: ShootingDaySceneScene) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.SCENES}/${shootingDayScene.scene.id}`;
  }

  public appendTotalRow() {
    const totalShootingDayScene = new ShootingDaySceneScene();
    let totalPlannedCount = 0;
    this.shootingDayScenes.forEach(
      (shootingDayScene: ShootingDaySceneScene) =>
        totalPlannedCount += shootingDayScene.plannedPageLength);
    totalShootingDayScene.plannedPageLength = totalPlannedCount;
    let totalCompletedCount = 0;
    this.shootingDayScenes.forEach(
      (shootingDayScene: ShootingDaySceneScene) =>
      totalCompletedCount += shootingDayScene.pageLength);
    totalShootingDayScene.pageLength = totalCompletedCount;
    this.shootingDayScenesWithTotalRow.push(totalShootingDayScene);
  }
}
