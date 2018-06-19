import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { ProjectSummary } from '../model/project-summary.model';
import { ProjectHelpers } from '../helpers/project.helpers';
@Injectable()
export class CurrentProjectService {
  public toggleCurrentProjectSource = new Subject<ProjectSummary>();
  public toggleCurrentProject$ = this.toggleCurrentProjectSource.asObservable();

  public setCurrentProject(project: ProjectSummary) {
    ProjectHelpers.setCurrentProject(project);
    this.toggleCurrentProjectSource.next(project);
  }

  public getCurrentProject() {
    return ProjectHelpers.getCurrentProject();
  }

  public resetCurrentProject() {
    ProjectHelpers.resetCurrentProject();
    this.toggleCurrentProjectSource.next(null);
  }
}
