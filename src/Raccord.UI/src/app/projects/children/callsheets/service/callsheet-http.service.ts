import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { FullCallsheet } from '../';
import { CallsheetSummary } from '../';
import { Callsheet } from '../';
import { JsonResponse } from '../../../../shared/model/json-response.model';

@Injectable()
export class CallsheetHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/callsheets`;
    }

    getAll(projectId): Promise<CallsheetSummary[]> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullCallsheet>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<CallsheetSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(callsheet: Callsheet): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(callsheet, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
