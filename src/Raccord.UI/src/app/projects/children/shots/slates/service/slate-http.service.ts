import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { Slate, SlateSummary, FullSlate } from '../../../..';

@Injectable()
export class SlateHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/slates`;
    }

    public getAll(projectId): Promise<SlateSummary[] | void> {

        const uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray<SlateSummary>(uri);
    }

    public get(id: number): Promise<FullSlate | void> {

        const uri = `${this._baseUri}/${id}`;

        return this.doGet<FullSlate>(uri);
    }

    public getSummary(id: number): Promise<SlateSummary | void> {

        const uri = `${this._baseUri}/${id}/summary`;

        return this.doGet<SlateSummary>(uri);
    }

    public post(slate: Slate): Promise<number> {
        const uri = this._baseUri;

        return this.doPost(slate, uri);
    }

    public delete(id: number): Promise<any> {
        const uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
