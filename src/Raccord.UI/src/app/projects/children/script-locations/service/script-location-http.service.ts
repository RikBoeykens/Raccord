import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { FullScriptLocation } from '../model/full-script-location.model';
import { ScriptLocationSummary } from '../model/script-location-summary.model';
import { ScriptLocation } from '../model/script-location.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { AuthService } from '../../../../security/service/auth.service';

@Injectable()
export class ScriptLocationHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ENDPOINT}/scriptlocations`;
    }

    getAll(projectId): Promise<ScriptLocationSummary[]> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullScriptLocation>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<ScriptLocationSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(location: ScriptLocation): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(location, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }

    merge(toId: Number, mergeId): Promise<any> {
        var uri = `${this._baseUri}/merge/${toId}/${mergeId}`;

        return this.doPost(null, uri);
    }
}
