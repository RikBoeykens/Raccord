import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { FullDayNight } from '../model/full-day-night.model';
import { DayNightSummary } from '../model/day-night-summary.model';
import { DayNight } from '../model/day-night.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';

@Injectable()
export class DayNightHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/daynights`;
    }

    getAll(projectId): Promise<DayNightSummary[] | void> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullDayNight | void>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<DayNightSummary | void> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(dayNight: DayNight): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(dayNight, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }

    merge(toId: Number, mergeId): Promise<any> {
        var uri = `${this._baseUri}/merge/${toId}/${mergeId}`;

        return this.doPost(null, uri);
    }
}