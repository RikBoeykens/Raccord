import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { IntExtHttpService } from './int-ext-http.service';
import { IntExtSummary } from '../model/int-ext-summary.model';
@Injectable()
export class IntExtsResolve implements Resolve<IntExtSummary[]> {

  constructor(
    private intExtHttpService: IntExtHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot): Promise<IntExtSummary[]>|boolean {
        let projectId = route.params['projectId'];
        return this.intExtHttpService.getAll(projectId).then(data => {
            return data;
        });
    }
}