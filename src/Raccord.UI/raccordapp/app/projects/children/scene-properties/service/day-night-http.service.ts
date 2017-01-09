import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { DayNightSummary } from '../model/day-night-summary.model';
import { DayNight } from '../model/day-night.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';

@Injectable()
export class DayNightHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/daynights`;
    }

    getAll(projectId): Promise<DayNightSummary[]> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<DayNight>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<DayNightSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(dayNight: DayNightSummary): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(dayNight, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}