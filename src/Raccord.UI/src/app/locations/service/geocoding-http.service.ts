import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { GeocodingResponse } from '../model/geocoding-response.model';
import { Address } from '../../shared';
import { AppSettings } from '../../app.settings';

@Injectable()
export class GeocodingHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/geocoding`;
    }

    public getLatLng(searchText: string): Promise<GeocodingResponse[] | void> {
      let uri = `${this._baseUri}/${searchText}`;

      return this.doGetArray(uri, false);
    }

    public getLatLngByAddress(request: Address): Promise<GeocodingResponse[]> {
      let uri = this._baseUri;

      return this.doPost(request, uri, false);
    }
}
