import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ProjectHttpService } from './project-http.service';
import { PagedData, PageRequest } from '../../paging';
import { UserProject } from '../model/user-project.model';

@Injectable()
export class PagedProjectsResolve implements Resolve<PagedData<UserProject>> {
  constructor(private _projectHttpService: ProjectHttpService) {}

  public resolve(route: ActivatedRouteSnapshot) {
    return this._projectHttpService.getPaged(new PageRequest({
      page: 1,
      pageSize: 12,
      full: false
    })).then((data) => {
      if (data) {
        return data as PagedData<UserProject>;
      }
    });
  }
}
