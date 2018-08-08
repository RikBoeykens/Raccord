import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CastDashboard } from '../model/cast-dashboard.model';
import { CastDashboardHttpService } from './cast-dashboard-http.service';

@Injectable()
export class CastDashboardResolve implements Resolve<CastDashboard> {

  constructor(
    private _castDashboardttpService: CastDashboardHttpService,
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const id = route.params['projectId'];
    return this._castDashboardttpService.get(id).then((data: CastDashboard) => data);
  }
}
