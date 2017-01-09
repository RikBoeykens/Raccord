import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { IntExtSummary } from '../model/int-ext-summary.model';
import { IntExt } from '../model/int-ext.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';

@Injectable()
export class IntExtHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/intexts`;
    }

    getAll(projectId): Promise<IntExtSummary[]> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<IntExt>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<IntExtSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(intExt: IntExtSummary): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(intExt, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
