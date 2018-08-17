import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../shared/children/projects';
import { ProjectHelpers } from '../../../shared/children/projects/helpers/project.helpers';
import { AccountHelpers } from '../../../shared/children/account';
import { ProjectPermissionEnum } from '../../../shared/children/users';
import { RouteSettings } from '../../../shared';

@Component({
  selector: 'project-dashboard',
  templateUrl: 'project-dashboard.component.html'
})
export class ProjectDashboardComponent implements OnInit {
  public project: ProjectSummary;

  constructor(
    private _route: ActivatedRoute,
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe(() => {
      this.project = ProjectHelpers.getCurrentProject();
    });
  }

  public getCanRead() {
      return AccountHelpers.hasProjectPermission(
          this.project.id,
          ProjectPermissionEnum.canReadGeneral
      );
  }

  public getScriptLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCRIPT}`;
  }

  public getLocationLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.LOCATIONSDASHBOARD}`;
  }

  public getSchedulingLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCHEDULING}`;
  }

  public getCastLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CASTDASHBOARD}`;
  }

  public getCrewLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CREW}`;
  }

  public getBreakdownLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.BREAKDOWNS}`;
  }

  public getSlatesLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SLATES}`;
  }
}
