import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CrewUnitDashboard } from '../model/crew-unit-dashboard.model';
import { CrewUnitDashboardHttpService } from './crew-unit-dashboard-http.service';

@Injectable()
export class CrewUnitDashboardResolve implements Resolve<CrewUnitDashboard> {

  constructor(
    private _crewUnitDashboardttpService: CrewUnitDashboardHttpService,
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const projectId = route.params['projectId'];
    const crewUnitId = route.params['crewUnitId'];
    return this._crewUnitDashboardttpService.get(projectId, crewUnitId)
      .then((data: CrewUnitDashboard) => data);
  }
}
