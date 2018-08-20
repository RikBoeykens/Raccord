import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SchedulingDashboard } from '../model/scheduling-dashboard.model';
import { SchedulingDashboardHttpService } from './scheduling-dashboard-http.service';

@Injectable()
export class SchedulingDashboardResolve implements Resolve<SchedulingDashboard> {

  constructor(
    private _schedulingDashboardttpService: SchedulingDashboardHttpService,
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const id = route.params['projectId'];
    return this._schedulingDashboardttpService.get(id).then((data: SchedulingDashboard) => data);
  }
}
