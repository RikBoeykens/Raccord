import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SlateHttpService } from './slate-http.service';
import { FullSlate } from "../model/full-slate.model";

@Injectable()
export class SlateResolve implements Resolve<FullSlate> {

  constructor(
      private slateHttpService: SlateHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let slateId = route.params['slateId'];

    return this.slateHttpService.get(slateId).then(slate => {
        if (slate) {
            return slate;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}