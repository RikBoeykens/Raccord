import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullBreakdownType } from '../model/full-breakdown-type.model';
import { BreakdownTypeSummary } from '../model/breakdown-type-summary.model';
import { BreakdownType } from '../model/breakdown-type.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';

@Injectable()
export class BreakdownTypeHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/breakdowntypes`;
    }

    getAll(projectId): Promise<BreakdownTypeSummary[]> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullBreakdownType>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<BreakdownTypeSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(breakdownType: BreakdownType): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(breakdownType, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
