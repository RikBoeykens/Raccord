import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseProjectHttpService } from '../../../../../shared/service/base-project-http.service';
import { CrewUnitDashboard } from '../model/crew-unit-dashboard.model';

@Injectable()
export class CrewUnitDashboardHttpService extends BaseProjectHttpService {

  constructor(protected _http: HttpClient) {
      super(_http, 'crewunitdashboard');
  }

  public get(authProjectId: number, crewUnitId: number): Promise<CrewUnitDashboard | void> {

    const uri = `${this.getUri(authProjectId)}/${crewUnitId}`;

    return this.doGet(uri);
  }
}
