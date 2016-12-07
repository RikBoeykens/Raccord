import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { IntExtService } from './int-ext.service';
import { IntExt } from '../model/int-ext.model';
@Injectable()
export class IntExtResolve implements Resolve<IntExt> {

  constructor(
      private intExtService: IntExtService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot): Promise<IntExt>|boolean {
    let intExtId = route.params['intExtId'];

    return this.intExtService.get(intExtId).then(intExt => {
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