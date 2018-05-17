import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { JsonResponse } from '../../../../../shared/model/json-response.model';
import { SlateSummary } from "../model/slate-summary.model";
import { FullSlate } from "../model/full-slate.model";
import { Slate } from "../model/slate.model";
import { AuthService } from '../../../../../security/service/auth.service';

@Injectable()
export class SlateHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ENDPOINT}/slates`;
    }

    getAll(projectId): Promise<SlateSummary[]> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullSlate>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<SlateSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
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