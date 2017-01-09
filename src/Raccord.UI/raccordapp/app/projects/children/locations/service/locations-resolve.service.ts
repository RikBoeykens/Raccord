import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { LocationHttpService } from './location-http.service';
import { LocationSummary } from '../model/location-summary.model';
@Injectable()
export class LocationsResolve implements Resolve<LocationSummary[]> {

  constructor(
    private locationHttpService: LocationHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot): Promise<LocationSummary[]>|boolean {
        let projectId = route.params['projectId'];
        return this.locationHttpService.getAll(projectId).then(data => {
            return data;
        });
    }
}