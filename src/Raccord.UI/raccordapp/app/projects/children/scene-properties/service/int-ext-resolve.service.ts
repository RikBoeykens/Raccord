import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { IntExtHttpService } from './int-ext-http.service';
import { IntExt } from '../model/int-ext.model';
@Injectable()
export class IntExtResolve implements Resolve<IntExt> {

  constructor(
      private intExtHttpService: IntExtHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot): Promise<IntExt>|boolean {
    let intExtId = route.params['intExtId'];

    return this.intExtHttpService.get(intExtId).then(intExt => {
        if (intExt) {
            return intExt;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}