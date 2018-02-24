import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CrewUnitSummary } from '../model/crew-unit-summary.model';
import { CrewUnitHttpService } from './crew-unit-http.service';
@Injectable()
export class CrewUnitSummaryResolve implements Resolve<CrewUnitSummary> {

  constructor(
      private crewUnitHttpService: CrewUnitHttpService,
      private router: Router
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    let crewUnitId = route.params['crewUnitId'];
    let projectId = route.params['projectId'];

    return this.crewUnitHttpService.getSummary(projectId, crewUnitId).then((crewUnit) => {
        if (crewUnit) {
            return crewUnit;
        } else { // id not found
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}
