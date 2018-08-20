import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import {
    LocationSetLocation,
    LocationSetScriptLocation,
    LocationSetSummary,
    LocationSet,
    FullLocationSet
} from '../../../../..';

@Injectable()
export class LocationSetHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/locationsets`;
    }

    public getLocations(id): Promise<LocationSetLocation[] | void> {

        const uri = `${this._baseUri}/${id}/scriptlocation`;

        return this.doGetArray(uri);
    }

    public getScriptLocations(id): Promise<LocationSetScriptLocation[] | void> {

        const uri = `${this._baseUri}/${id}/location`;

        return this.doGetArray(uri);
    }

    public getForScene(id): Promise<LocationSetSummary[] | void> {

        const uri = `${this._baseUri}/${id}/scene`;

        return this.doGetArray(uri);
    }

    public get(id: number): Promise<FullLocationSet | void> {

        const uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public post(locationSet: LocationSet): Promise<number> {
        const uri = this._baseUri;

        return this.doPost(locationSet, uri);
    }

    public delete(id: number): Promise<any> {
        const uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
