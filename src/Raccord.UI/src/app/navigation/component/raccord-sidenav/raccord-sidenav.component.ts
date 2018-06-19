import { Component, OnInit, OnChanges } from '@angular/core';
import { ProjectSummary, CurrentProjectService } from '../../../shared/children/projects';

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
}
