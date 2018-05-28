import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { TakeSummary } from "../model/take-summary.model";
import { FullTake } from "../model/full-take.model";
import { Take } from "../model/take.model";

@Injectable()
export class TakeHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/takes`;
    }

    getAll(slateId): Promise<TakeSummary[] | void> {

        var uri = `${this._baseUri}/${slateId}/slate`;

        return this.doGetArray<TakeSummary>(uri);
    }

    get(id: number): Promise<FullTake | void> {

        var uri = `${this._baseUri}/${id}`;

        return this.doGet<FullTake>(uri);
    }

    getSummary(id: Number): Promise<TakeSummary | void> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet<TakeSummary>(uri);
    }

    post(take: Take): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(take, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}