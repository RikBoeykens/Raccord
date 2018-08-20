import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import { BreakdownType, BreakdownTypeSummary, FullBreakdownType } from '../../../../..';

@Injectable()
export class BreakdownTypeHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/breakdowntypes`;
    }

    public getAllForBreakdown(breakdownId): Promise<BreakdownTypeSummary[] | void> {

        const uri = `${this._baseUri}/${breakdownId}/breakdown`;

        return this.doGetArray(uri);
    }

    public get(id: number): Promise<FullBreakdownType | void> {

        const uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(id: number): Promise<BreakdownTypeSummary | void> {

        const uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    public post(breakdownType: BreakdownType): Promise<number> {
        const uri = this._baseUri;

        return this.doPost(breakdownType, uri);
    }

    public delete(id: number): Promise<any> {
        const uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
