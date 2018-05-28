import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { JsonResponse } from '../../../../../shared/model/json-response.model';
import { SlateSummary } from "../model/slate-summary.model";
import { FullSlate } from "../model/full-slate.model";
import { Slate } from "../model/slate.model";

@Injectable()
export class SlateHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/slates`;
    }

    getAll(projectId): Promise<SlateSummary[] | void> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray<SlateSummary>(uri);
    }

    get(id: number): Promise<FullSlate | void> {

        var uri = `${this._baseUri}/${id}`;

        return this.doGet<FullSlate>(uri);
    }

    getSummary(id: Number): Promise<SlateSummary | void> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet<SlateSummary>(uri);
    }

    post(slate: Slate): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(slate, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}