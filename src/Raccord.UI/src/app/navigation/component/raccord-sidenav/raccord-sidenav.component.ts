import { Component, OnInit, OnChanges } from '@angular/core';
import { ProjectSummary, CurrentProjectService } from '../../../shared/children/projects';
import { AccountHelpers } from '../../../shared/children/account';
import { RouteSettings } from '../../../shared';

@Component({
  selector: 'raccord-sidenav',
  templateUrl: 'raccord-sidenav.component.html',
})
export class RaccordSidenavComponent implements OnInit {
  public currentProject: ProjectSummary;

  constructor(
    private _currentProjectService: CurrentProjectService
  ) {
    _currentProjectService.toggleCurrentProject$.subscribe((project: ProjectSummary) => {
      this.currentProject = project;
    });
  }

  public ngOnInit() {
    this.currentProject = this._currentProjectService.getCurrentProject();
  }

  public isAdmin() {
    return AccountHelpers.isAdmin();
  }

  public getProfileLink() {
    return `/${RouteSettings.PROFILE}`;
  }

  public getAdminLink() {
    return `/${RouteSettings.ADMIN}`;
  }

  public getProjectLink() {
      return `/${RouteSettings.PROJECTS}`;
  }

  public getScriptLink() {
      return `/${RouteSettings.PROJECTS}/${this.currentProject.id}/${RouteSettings.SCRIPT}`;
  }
}
