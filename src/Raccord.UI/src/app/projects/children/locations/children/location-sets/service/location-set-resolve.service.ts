import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { LocationSetHttpService } from './location-set-http.service';
import { FullLocationSet } from '../model/full-location-set.model';
@Injectable()
export class LocationSetResolve implements Resolve<FullLocationSet> {

  constructor(
      private locationSetHttpService: LocationSetHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const locationSetId = route.params['locationSetId'];
    // tslint:disable-next-line:max-line-length
    return this.locationSetHttpService.get(locationSetId).then((locationSet: FullLocationSet) => locationSet);
  }
}
