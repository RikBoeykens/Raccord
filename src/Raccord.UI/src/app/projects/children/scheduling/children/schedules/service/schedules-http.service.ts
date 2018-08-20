import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PagedData } from '../../../../../../shared/children/paging';
import { ScheduleCrewUnitSummary } from '../../../../..';
import { BaseProjectHttpService } from '../../../../../shared/service/base-project-http.service';

@Injectable()
export class SchedulesHttpService extends BaseProjectHttpService {

  constructor(protected _http: HttpClient) {
      super(_http, 'schedules');
  }

  public get(authProjectId: number): Promise<PagedData<ScheduleCrewUnitSummary> | void> {

    const uri = this.getUri(authProjectId);

    return this.doGet(uri);
  }
}
