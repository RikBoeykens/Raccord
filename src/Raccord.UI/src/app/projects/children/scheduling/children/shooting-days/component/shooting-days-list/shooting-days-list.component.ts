import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShootingDayCrewUnit } from '../../../../../..';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  templateUrl: 'shooting-days-list.component.html'
})
export class ShootingDaysListComponent implements OnInit {
  public shootingDays: ShootingDayCrewUnit[];
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        shootingDays: ShootingDayCrewUnit[]
      }) => {
          this.shootingDays = data.shootingDays;
      });
      this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCHEDULING}`;
  }

  public getShootingDayLink(shootingDay: ShootingDayCrewUnit) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SHOOTINGDAYS}/${shootingDay.id}`;
  }
}
