import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullLocation } from '../model/full-location.model';
import { LocationSummary } from '../model/location-summary.model';
import { Location } from '../model/location.model';
import { JsonResponse } from '../../../../../shared/model/json-response.model';
import { AuthService } from '../../../../../security/service/auth.service';

@Injectable()
export class LocationHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ENDPOINT}/locations`;
    }

    getAll(projectId): Promise<LocationSummary[]> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullLocation>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<LocationSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(location: Location): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(location, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}