import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CrewUnitSummary } from '../../../../../../shared/children/crew';
import { CrewUnitHttpService } from '../../../../..';

@Injectable()
export class CrewUnitSummaryResolve implements Resolve<CrewUnitSummary> {

  constructor(
      private crewUnitHttpService: CrewUnitHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const crewUnitId = route.params['crewUnitId'];
    const projectId = route.params['projectId'];

    // tslint:disable-next-line:max-line-length
    return this.crewUnitHttpService.getSummary(projectId, crewUnitId).then((data: CrewUnitSummary) => data);
  }
}
