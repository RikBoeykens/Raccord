import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ScheduleDayHttpService } from './schedule-day-http.service';
import { FullScheduleDay } from '../../../../../../..';
@Injectable()
export class ScheduleDaysResolve implements Resolve<FullScheduleDay[]> {

  constructor(
    private scheduleDayHttpService: ScheduleDayHttpService
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const projectId = route.params['projectId'];
        const crewUnitId = route.params['crewUnitId'];
        // tslint:disable-next-line:max-line-length
        return this.scheduleDayHttpService.getAll(projectId, crewUnitId).then((data: FullScheduleDay[]) => data);
    }
}
