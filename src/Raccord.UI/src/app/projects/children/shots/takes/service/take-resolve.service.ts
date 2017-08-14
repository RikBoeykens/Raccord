import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { TakeHttpService } from './take-http.service';
import { FullTake } from "../model/full-take.model";

@Injectable()
export class TakeResolve implements Resolve<FullTake> {

  constructor(
      private takeHttpService: TakeHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let takeId = route.params['takeId'];

    return this.takeHttpService.get(takeId).then(take => {
        if (take) {
            return take;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}