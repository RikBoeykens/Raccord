import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { LocationService } from './location.service';
import { LocationSummary } from '../model/location-summary.model';
@Injectable()
export class LocationsResolve implements Resolve<LocationSummary[]> {

  constructor(
    private locationService: LocationService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot): Promise<LocationSummary[]>|boolean {
        let projectId = route.params['projectId'];
        return this.locationService.getAll(projectId).then(data => {
            return data;
        });
    }
}