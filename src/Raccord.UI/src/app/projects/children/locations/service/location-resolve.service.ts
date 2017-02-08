import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { LocationHttpService } from './location-http.service';
import { Location } from '../model/location.model';
@Injectable()
export class LocationResolve implements Resolve<Location> {

  constructor(
      private locationHttpService: LocationHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let locationId = route.params['locationId'];

    return this.locationHttpService.get(locationId).then(location => {
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