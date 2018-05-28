import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../../app.settings';
import { BaseProjectHttpService } from '../../../shared/service/base-project-http.service';
import { BreakdownSummary } from '../model/breakdown-summary.model';
import { FullBreakdown } from '../model/full-breakdown.model';
import { Breakdown } from '../model/breakdown.model';
import { PublishBreakdown } from '../model/publish-breakdown.model';
import { SelectedBreakdown } from '../model/selected-breakdown.model';

@Injectable()
export class BreakdownHttpService extends BaseProjectHttpService {

    constructor(protected _http: HttpClient) {
        super(_http, 'breakdowns');
    }

    public getAll(authProjectId: number): Promise<BreakdownSummary[] | void> {

        let uri = `${this.getUri(authProjectId)}/project`;

        return this.doGetArray(uri);
    }

    public get(authProjectId: number, id: number): Promise<FullBreakdown | void> {

        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(authProjectId: number, id: Number): Promise<BreakdownSummary | void> {

        let uri = `${this.getUri(authProjectId)}/${id}/summary`;

        return this.doGet(uri);
    }

    public getSelected(authProjectId: number): Promise<SelectedBreakdown | void> {

        let uri = `${this.getUri(authProjectId)}/selected`;

        return this.doGet(uri);
    }

    public post(authProjectId: number, breakdown: Breakdown): Promise<number> {
        let uri = this.getUri(authProjectId);

        return this.doPost(breakdown, uri);
    }

    public delete(authProjectId: number, id: Number): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doDelete(uri);
    }

    public select(authProjectId: number, id: Number): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/${id}/select`;

        return this.doPost(null, uri);
    }

    public togglePublish(authProjectId: number, id: Number, publish: boolean): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/${id}/publish`;

        return this.doPost(new PublishBreakdown({
            publish
        }), uri);
    }

    public setDefault(authProjectId: number, id: Number): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/${id}/default`;

        return this.doPost(null, uri);
    }
}
