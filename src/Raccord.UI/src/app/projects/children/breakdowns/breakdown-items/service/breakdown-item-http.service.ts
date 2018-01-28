import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullBreakdownItem } from '../model/full-breakdown-item.model';
import { BreakdownItemSummary } from '../model/breakdown-item-summary.model';
import { BreakdownItem } from '../model/breakdown-item.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { SearchBreakdownItemRequest } from '../model/search-breakdown-item-request.model';

@Injectable()
export class BreakdownItemHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/breakdownitems`;
    }

    getAll(typeId): Promise<BreakdownItem[]> {

        var uri = `${this._baseUri}/${typeId}/type`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullBreakdownItem>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<BreakdownItemSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(breakdownItem: BreakdownItem): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(breakdownItem, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }

    merge(toId: Number, mergeId): Promise<any> {
        var uri = `${this._baseUri}/merge/${toId}/${mergeId}`;

        return this.doPost(null, uri);
    }

    searchByType(request: SearchBreakdownItemRequest): Promise<BreakdownItem[]> {

        var uri = `${this._baseUri}/search`;

        return this.doPost(request, uri);
    }
}
