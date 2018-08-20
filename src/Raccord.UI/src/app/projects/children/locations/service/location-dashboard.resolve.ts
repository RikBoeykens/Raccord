import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { LocationDashboard } from '../model/location-dashboard.model';
import { LocationDashboardHttpService } from './location-dashboard-http.service';

@Injectable()
export class LocationDashboardResolve implements Resolve<LocationDashboard> {

  constructor(
    private _locationDashboardttpService: LocationDashboardHttpService,
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const id = route.params['projectId'];
    return this._locationDashboardttpService.get(id).then((data: LocationDashboard) => data);
  }
}
