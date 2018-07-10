import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminDashboard } from '../model/admin-dashboard.model';
import { AdminDashboardHttpService } from './admin-dashboard-http.service';

@Injectable()
export class AdminDashboardResolve implements Resolve<AdminDashboard> {

  constructor(
    private _adminDashboardttpService: AdminDashboardHttpService,
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    return this._adminDashboardttpService.get().then((data: AdminDashboard) => data);
  }
}
