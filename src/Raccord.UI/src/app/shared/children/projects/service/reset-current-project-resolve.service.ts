import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ProjectHelpers } from '../helpers/project.helpers';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/of';
import { CurrentProjectService } from './current-project.service';

@Injectable()
export class ResetCurrentProjectResolve implements Resolve<void> {

  constructor(
    private _currentProjectService: CurrentProjectService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    this._currentProjectService.resetCurrentProject();
    return Observable.of(null).toPromise();
  }
}
