import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminCrewUnitHttpService } from './admin-crew-unit-http.service';
import { FullAdminCrewUnit } from
    '../../../projects/children/crew/crew-units/model/full-admin-crew-unit.model';
@Injectable()
export class AdminCrewUnitResolve implements Resolve<FullAdminCrewUnit> {

  constructor(
      private crewUnitHttpService: AdminCrewUnitHttpService,
      private router: Router
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    let crewUnitId = route.params['crewUnitId'];
    let projectId = route.params['projectId'];

    return this.crewUnitHttpService.get(crewUnitId).then((crewUnit) => {
        if (crewUnit) {
            return crewUnit;
        } else { // id not found
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}
