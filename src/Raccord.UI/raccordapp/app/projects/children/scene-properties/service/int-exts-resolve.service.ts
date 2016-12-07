import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { IntExtService } from './int-ext.service';
import { IntExtSummary } from '../model/int-ext-summary.model';
@Injectable()
export class IntExtsResolve implements Resolve<IntExtSummary[]> {

  constructor(
    private intExtService: IntExtService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot): Promise<IntExtSummary[]>|boolean {
        let projectId = route.params['projectId'];
        return this.intExtService.getAll(projectId).then(data => {
            return data;
        });
    }
}