import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullLocationSet } from '../model/full-location-set.model';
import { LocationSetLocation } from '../model/location-set-location.model';
import { LocationSetScriptLocation } from '../model/location-set-script-location.model';
import { LocationSetSummary } from '../model/location-set-summary.model';
import { LocationSet } from '../model/location-set.model';
import { JsonResponse } from '../../../../../shared/model/json-response.model';

@Injectable()
export class LocationSetHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/locationsets`;
    }

    getLocations(id): Promise<LocationSetLocation[]> {

        var uri = `${this._baseUri}/${id}/scriptlocation`;

        return this.doGetArray(uri);
    }

    getScriptLocations(id): Promise<LocationSetScriptLocation[]> {

        var uri = `${this._baseUri}/${id}/location`;

        return this.doGetArray(uri);
    }

    getForScene(id): Promise<LocationSetSummary[]> {

        var uri = `${this._baseUri}/${id}/scene`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullLocationSet>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    post(locationSet: LocationSet): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(locationSet, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}