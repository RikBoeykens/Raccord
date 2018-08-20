import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseProjectHttpService } from '../../../shared/service/base-project-http.service';
import { ScriptDashboard } from '../model/script-dashboard.model';

@Injectable()
export class ScriptDashboardHttpService extends BaseProjectHttpService {

  constructor(protected _http: HttpClient) {
      super(_http, 'scriptdashboard');
  }

  public get(authProjectId: number): Promise<ScriptDashboard | void> {

    const uri = this.getUri(authProjectId);

    return this.doGet(uri);
  }
}
