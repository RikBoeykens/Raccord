import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ScriptLocationHttpService } from './script-location-http.service';
import { FullScriptLocation } from '../model/full-script-location.model';
@Injectable()
export class ScriptLocationResolve implements Resolve<FullScriptLocation> {

  constructor(
      private scriptLocationHttpService: ScriptLocationHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let scriptLocationId = route.params['scriptLocationId'];

    return this.scriptLocationHttpService.get(scriptLocationId).then(scriptLocation => {
        if (scriptLocation) {
            return scriptLocation;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}