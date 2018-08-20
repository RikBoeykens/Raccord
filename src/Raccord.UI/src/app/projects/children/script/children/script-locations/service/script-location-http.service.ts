import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import {
  ScriptLocationSummary,
  ScriptLocation
} from '../../../../../../shared/children/script-locations';
import { FullScriptLocation } from '../../../../..';

@Injectable()
export class ScriptLocationHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ENDPOINT}/scriptlocations`;
  }

  public getAll(projectId): Promise<ScriptLocationSummary[] | void> {

    const uri = `${this._baseUri}/${projectId}/project`;

    return this.doGetArray(uri);
  }

  public get(id: number): Promise<FullScriptLocation | void> {

    const uri = `${this._baseUri}/${id}`;

    return this.doGet(uri);
  }

  public getSummary(id: number): Promise<ScriptLocationSummary | void> {

    const uri = `${this._baseUri}/${id}/summary`;

    return this.doGet(uri);
  }

  public post(location: ScriptLocation): Promise<number> {
    const uri = this._baseUri;

    return this.doPost(location, uri);
  }

  public delete(id: number): Promise<any> {
    const uri = `${this._baseUri}/${id}`;

    return this.doDelete(uri);
  }

  public merge(toId: number, mergeId): Promise<any> {
    const uri = `${this._baseUri}/merge/${toId}/${mergeId}`;

    return this.doPost(null, uri);
  }
}
