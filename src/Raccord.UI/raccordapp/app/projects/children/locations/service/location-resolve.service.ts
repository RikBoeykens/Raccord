import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { LocationService } from './location.service';
import { Location } from '../model/location.model';
@Injectable()
export class LocationResolve implements Resolve<Location> {

  constructor(
      private locationService: LocationService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot): Promise<Location>|boolean {
    let locationId = route.params['locationId'];

    return this.locationService.get(locationId).then(location => {
        if (location) {
            return location;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}