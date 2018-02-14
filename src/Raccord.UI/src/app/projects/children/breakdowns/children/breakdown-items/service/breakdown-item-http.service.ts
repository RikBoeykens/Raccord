import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
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

    public getAll(typeId): Promise<BreakdownItem[]> {

        let uri = `${this._baseUri}/${typeId}/type`;

        return this.doGetArray(uri);
    }

    public get(id: number): Promise<FullBreakdownItem> {

        let uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(id: Number): Promise<BreakdownItemSummary> {

        let uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    public post(breakdownItem: BreakdownItem): Promise<number> {
        let uri = this._baseUri;

        return this.doPost(breakdownItem, uri);
    }

    public delete(id: Number): Promise<any> {
        let uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }

    public merge(toId: Number, mergeId): Promise<any> {
        let uri = `${this._baseUri}/merge/${toId}/${mergeId}`;

        return this.doPost(null, uri);
    }

    public searchByType(request: SearchBreakdownItemRequest): Promise<BreakdownItem[]> {

        let uri = `${this._baseUri}/search`;

        return this.doPost(request, uri);
    }
}
