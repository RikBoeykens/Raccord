import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { CallsheetSummary, CallsheetCrewUnit, FullCallsheet, Callsheet } from '../../..';

@Injectable()
export class CallsheetHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ENDPOINT}/callsheets`;
  }

  public getAll(crewUnitId): Promise<CallsheetSummary[] | void> {

    const uri = `${this._baseUri}/${crewUnitId}/crewUnit`;

    return this.doGetArray(uri);
  }

  public getAllForProject(projectId): Promise<CallsheetCrewUnit[] | void> {

    const uri = `${this._baseUri}/${projectId}/project`;

    return this.doGetArray(uri);
  }

  public get(id: number): Promise<FullCallsheet | void> {

    const uri = `${this._baseUri}/${id}`;

    return this.doGet(uri);
  }

  public getSummary(id: number): Promise<CallsheetSummary | void> {

    const uri = `${this._baseUri}/${id}/summary`;

    return this.doGet(uri);
  }

  public post(callsheet: Callsheet): Promise<number> {
    const uri = this._baseUri;

    return this.doPost(callsheet, uri);
  }

  public delete(id: number): Promise<any> {
    const uri = `${this._baseUri}/${id}`;

    return this.doDelete(uri);
  }
}
