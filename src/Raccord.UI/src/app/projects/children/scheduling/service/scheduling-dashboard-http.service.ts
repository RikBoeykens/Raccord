import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseProjectHttpService } from '../../../shared/service/base-project-http.service';
import { SchedulingDashboard } from '../model/scheduling-dashboard.model';

@Injectable()
export class SchedulingDashboardHttpService extends BaseProjectHttpService {

  constructor(protected _http: HttpClient) {
      super(_http, 'schedulingdashboard');
  }

  public get(authProjectId: number): Promise<SchedulingDashboard | void> {

    const uri = this.getUri(authProjectId);

    return this.doGet(uri);
  }
}
