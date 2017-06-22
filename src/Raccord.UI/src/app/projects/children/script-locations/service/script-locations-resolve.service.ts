import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ScriptLocationHttpService } from './script-location-http.service';
import { ScriptLocationSummary } from '../model/script-location-summary.model';
@Injectable()
export class ScriptLocationsResolve implements Resolve<ScriptLocationSummary[]> {

  constructor(
    private scriptLocationHttpService: ScriptLocationHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this.scriptLocationHttpService.getAll(projectId).then(data => {
            return data;
        });
    }
}