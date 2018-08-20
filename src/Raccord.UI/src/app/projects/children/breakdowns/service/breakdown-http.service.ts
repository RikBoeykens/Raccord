import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseProjectHttpService } from '../../../shared/service/base-project-http.service';
import {
    PublishBreakdown,
    Breakdown,
    SelectedBreakdown,
    BreakdownSummary,
    FullBreakdown
} from '../../..';

@Injectable()
export class BreakdownHttpService extends BaseProjectHttpService {

    constructor(protected _http: HttpClient) {
        super(_http, 'breakdowns');
    }

    public getAll(authProjectId: number): Promise<BreakdownSummary[] | void> {

        const uri = `${this.getUri(authProjectId)}/project`;

        return this.doGetArray(uri);
    }

    public get(authProjectId: number, id: number): Promise<FullBreakdown | void> {

        const uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(authProjectId: number, id: number): Promise<BreakdownSummary | void> {

        const uri = `${this.getUri(authProjectId)}/${id}/summary`;

        return this.doGet(uri);
    }

    public getSelected(authProjectId: number): Promise<SelectedBreakdown | void> {

        const uri = `${this.getUri(authProjectId)}/selected`;

        return this.doGet(uri);
    }

    public post(authProjectId: number, breakdown: Breakdown): Promise<number> {
        const uri = this.getUri(authProjectId);

        return this.doPost(breakdown, uri);
    }

    public delete(authProjectId: number, id: number): Promise<any> {
        const uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doDelete(uri);
    }

    public select(authProjectId: number, id: number): Promise<any> {
        const uri = `${this.getUri(authProjectId)}/${id}/select`;

        return this.doPost(null, uri);
    }

    public togglePublish(authProjectId: number, id: number, publish: boolean): Promise<any> {
        const uri = `${this.getUri(authProjectId)}/${id}/publish`;

        return this.doPost(new PublishBreakdown({
            publish
        }), uri);
    }

    public setDefault(authProjectId: number, id: number): Promise<any> {
        const uri = `${this.getUri(authProjectId)}/${id}/default`;

        return this.doPost(null, uri);
    }
}
