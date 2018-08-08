import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseProjectHttpService } from '../../../shared/service/base-project-http.service';
import { LocationDashboard } from '../model/location-dashboard.model';

@Injectable()
export class LocationDashboardHttpService extends BaseProjectHttpService {

  constructor(protected _http: HttpClient) {
      super(_http, 'locationdashboard');
  }

  public get(authProjectId: number): Promise<LocationDashboard | void> {

    const uri = this.getUri(authProjectId);

    return this.doGet(uri);
  }
}
