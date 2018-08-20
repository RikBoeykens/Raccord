import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { LocationHttpService } from './location-http.service';
import { FullLocation } from '../model/full-location.model';
@Injectable()
export class LocationResolve implements Resolve<FullLocation> {

  constructor(
      private locationHttpService: LocationHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const id = route.params['locationId'];

    return this.locationHttpService.get(id).then((location: FullLocation) => location);
  }
}
