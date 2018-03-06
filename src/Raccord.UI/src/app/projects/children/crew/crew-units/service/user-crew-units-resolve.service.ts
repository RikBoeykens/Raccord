import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CrewUnitSummary } from '../model/crew-unit-summary.model';
import { CrewUnitHttpService } from './crew-unit-http.service';
@Injectable()
export class UserCrewUnitsResolve implements Resolve<CrewUnitSummary[]> {

  constructor(
    private _crewUnitHttpService: CrewUnitHttpService,
    private router: Router
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this._crewUnitHttpService.getAllForUser(projectId).then((data) => {
            return data;
        });
    }
}
