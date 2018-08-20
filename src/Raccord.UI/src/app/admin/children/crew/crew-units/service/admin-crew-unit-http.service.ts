import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullAdminCrewUnit } from '../../../..';
import { CrewUnitSummary } from '../../../../../shared/children/crew';

@Injectable()
export class AdminCrewUnitHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/crewunits`;
  }

  public get(id: number): Promise<FullAdminCrewUnit | void> {

    const uri = `${this._baseUri}/${id}`;

    return this.doGet(uri);
  }

  public getforProject(projectId: number): Promise<CrewUnitSummary[] | void> {

    const uri = `${this._baseUri}/${projectId}/project`;

    return this.doGetArray(uri);
  }
}
