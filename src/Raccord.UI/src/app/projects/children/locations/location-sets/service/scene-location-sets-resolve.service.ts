import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { LocationSetHttpService } from './location-set-http.service';
import { LocationSetSummary } from '../model/location-set-summary.model';
@Injectable()
export class SceneLocationSetsResolve implements Resolve<LocationSetSummary[]> {

  constructor(
    private locationSetHttpService: LocationSetHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let sceneId = route.params['sceneId'];
        return this.locationSetHttpService.getForScene(sceneId).then(data => {
            return data;
        });
    }
}