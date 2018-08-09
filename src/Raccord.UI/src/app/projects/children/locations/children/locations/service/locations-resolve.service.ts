import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { LocationHttpService } from './location-http.service';
import { LocationSummary } from '../model/location-summary.model';
@Injectable()
export class LocationsResolve implements Resolve<LocationSummary[]> {

  constructor(
    private locationHttpService: LocationHttpService
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const id = route.params['projectId'];
        return this.locationHttpService.getAll(id).then((data: LocationSummary[]) => data);
    }
}
