import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseProjectHttpService } from '../../../shared/service/base-project-http.service';
import { CastDashboard } from '../model/cast-dashboard.model';

@Injectable()
export class CastDashboardHttpService extends BaseProjectHttpService {

  constructor(protected _http: HttpClient) {
      super(_http, 'castdashboard');
  }

  public get(authProjectId: number): Promise<CastDashboard | void> {

    const uri = this.getUri(authProjectId);

    return this.doGet(uri);
  }
}
