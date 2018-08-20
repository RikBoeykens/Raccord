import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CrewUnitHttpService, FullCrewUnit } from '../../../../..';

@Injectable()
export class CrewUnitResolve implements Resolve<FullCrewUnit> {

  constructor(
      private crewUnitHttpService: CrewUnitHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const crewUnitId = route.params['crewUnitId'];
    const projectId = route.params['projectId'];

    // tslint:disable-next-line:max-line-length
    return this.crewUnitHttpService.get(projectId, crewUnitId).then((data: FullCrewUnit) => data);
  }
}
