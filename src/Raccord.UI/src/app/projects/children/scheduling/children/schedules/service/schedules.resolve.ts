import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SchedulesHttpService } from './schedules-http.service';
import { PagedData } from '../../../../../../shared/children/paging';
import { ScheduleSummary } from '../../../../..';

@Injectable()
export class SchedulesResolve implements Resolve<PagedData<ScheduleSummary>> {

  constructor(
    private _schedulesHttpService: SchedulesHttpService,
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const id = route.params['projectId'];
    return this._schedulesHttpService.get(id).then((data: PagedData<ScheduleSummary>) => data);
  }
}
