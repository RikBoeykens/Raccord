import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { AppSettings } from '../../../../app.settings';
import { BaseProjectHttpService } from '../../../shared/service/base-project-http.service';
import { BreakdownSummary } from '../model/breakdown-summary.model';
import { FullBreakdown } from '../model/full-breakdown.model';
import { Breakdown } from '../model/breakdown.model';

@Injectable()
export class BreakdownHttpService extends BaseProjectHttpService {

    constructor(protected _http: Http) {
        super(_http, 'breakdowns');
    }

    public getAll(authProjectId: number): Promise<BreakdownSummary[]> {

        let uri = `${this.getUri(authProjectId)}/project`;

        return this.doGetArray(uri);
    }

    public get(authProjectId: number, id: number): Promise<FullBreakdown> {

        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(authProjectId: number, id: Number): Promise<BreakdownSummary> {

        let uri = `${this.getUri(authProjectId)}/${id}/summary`;

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
}
