import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import { FullShootingDay, SlateSummary, ShootingDaySceneScene } from '../../../../../..';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings, Completion } from '../../../../../../../shared';

@Component({
  templateUrl: 'shooting-day-landing.component.html',
})
export class ShootingDayLandingComponent implements OnInit {
  public project: ProjectSummary;
  public shootingDay: FullShootingDay;

  constructor(
      private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: {
      shootingDay: FullShootingDay
    }) => {
      this.project = ProjectHelpers.getCurrentProject();
      this.shootingDay = data.shootingDay;
    });
  }

  public getBackLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SHOOTINGDAYS}`;
  }

  public getCrewUnitLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.UNITS}/${this.shootingDay.crewUnit.id}`;
  }

  public getSlateLink(slate: SlateSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SLATES}/${slate.id}`;
  }

  public getCameraRolls() {
    return this.shootingDay.cameraRolls.join(', ');
  }

  public getSoundRolls() {
    return this.shootingDay.soundRolls.join(', ');
  }

  public getCompletedScenesCount() {
      return this.shootingDay.scenes.filter((scene: ShootingDaySceneScene) =>
        scene.completion === Completion.completed ).length;
  }

  public getCompletedPagelengthCount() {
    let totalPageLength = 0;
    this.shootingDay.scenes.forEach((scene: ShootingDaySceneScene) => {
      totalPageLength += scene.pageLength;
    });
    return totalPageLength;
  }
}
