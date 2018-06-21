import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../shared/children/projects';
import { ProjectHelpers } from '../../../shared/children/projects/helpers/project.helpers';
import { AccountHelpers } from '../../../shared/children/account';
import { ProjectPermissionEnum } from '../../../shared/children/users';

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
}
