import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { LocationSetHttpService } from './location-set-http.service';
import { LocationSetSummary } from '../model/location-set-summary.model';
@Injectable()
export class SceneLocationSetsResolve implements Resolve<LocationSetSummary[]> {

  constructor(
    private locationSetHttpService: LocationSetHttpService
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const sceneId = route.params['sceneId'];
        // tslint:disable-next-line:max-line-length
        return this.locationSetHttpService.getForScene(sceneId).then((data: LocationSetSummary[]) => data);
    }
}
