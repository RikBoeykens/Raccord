import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { TakeHttpService } from "./take-http.service";
import { TakeSummary } from "../model/take-summary.model";
@Injectable()
export class TakesResolve implements Resolve<TakeSummary[]> {

  constructor(
    private takeHttpService: TakeHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let slateId = route.params['slateId'];
        return this.takeHttpService.getAll(slateId).then(data => {
            return data;
        });
    }
}