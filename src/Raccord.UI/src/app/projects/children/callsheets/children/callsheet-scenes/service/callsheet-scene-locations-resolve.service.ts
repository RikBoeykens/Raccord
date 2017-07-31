import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CallsheetSceneHttpService } from './callsheet-scene-http.service';
import { CallsheetSceneLocation } from '../../../';
@Injectable()
export class CallsheetSceneLocationsResolve implements Resolve<CallsheetSceneLocation[]> {

  constructor(
    private _callsheetSceneHttpService: CallsheetSceneHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let callsheetId = route.params['callsheetId'];
        return this._callsheetSceneHttpService.getLocations(callsheetId).then(data => {
            return data;
        });
    }
}