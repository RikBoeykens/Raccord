import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SlateHttpService } from "./slate-http.service";
import { SlateSummary } from "../model/slate-summary.model";
@Injectable()
export class SlatesResolve implements Resolve<SlateSummary[]> {

  constructor(
    private slateHttpService: SlateHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this.slateHttpService.getAll(projectId).then(data => {
            return data;
        });
    }
}