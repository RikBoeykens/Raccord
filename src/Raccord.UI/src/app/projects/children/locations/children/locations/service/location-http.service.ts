import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import { LocationSummary, FullLocation } from '../../../../..';

@Injectable()
export class LocationHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/locations`;
    }

    public getAll(projectId): Promise<LocationSummary[] | void> {

        const uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    public get(id: number): Promise<FullLocation | void> {

        const uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(id: number): Promise<LocationSummary | void> {

        const uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    public post(location: Location): Promise<number> {
        const uri = this._baseUri;

        return this.doPost(location, uri);
    }

    public delete(id: number): Promise<any> {
        const uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
