import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CrewUnitHttpService } from './crew-unit-http.service';
import { CrewUnitSummary } from '../../../../../../shared/children/crew';
@Injectable()
export class CrewUnitsResolve implements Resolve<CrewUnitSummary[]> {

  constructor(
    private _crewUnitHttpService: CrewUnitHttpService,
    private router: Router
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const projectId = route.params['projectId'];
        return this._crewUnitHttpService.getAll(projectId).then((data: CrewUnitSummary[]) => data);
    }
}
