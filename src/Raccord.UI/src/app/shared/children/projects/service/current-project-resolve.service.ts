import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ProjectHttpService } from './project-http.service';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/of';
import { ProjectSummary } from '../model/project-summary.model';
import { CurrentProjectService } from './current-project.service';

@Injectable()
export class CurrentProjectResolve implements Resolve<void> {
  constructor(
    private _projectHttpService: ProjectHttpService,
    private _currentProjectService: CurrentProjectService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const currentProject = this._currentProjectService.getCurrentProject();
    const projectId = parseInt(route.params['projectId'], 10);
    if (currentProject && currentProject.id === projectId) {
      return Observable.of(null).toPromise();
    }
    return this._projectHttpService.getSummary(projectId).then((data: ProjectSummary) => {
      this._currentProjectService.setCurrentProject(data);
    });
  }
}
