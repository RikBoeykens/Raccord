import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { LocationSetHttpService } from './location-set-http.service';
import { FullLocationSet } from '../model/full-location-set.model';
@Injectable()
export class LocationSetResolve implements Resolve<FullLocationSet> {

  constructor(
      private locationSetHttpService: LocationSetHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let locationSetId = route.params['locationSetId'];

    return this.locationSetHttpService.get(locationSetId).then(locationSet => {
        if (locationSet) {
            return locationSet;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}