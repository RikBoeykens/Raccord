import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullScheduleDay } from '../model/full-schedule-day.model';
import { ScheduleDaySummary } from '../model/schedule-day-summary.model';
import { ScheduleDay } from '../model/schedule-day.model';
import { JsonResponse } from '../../../../../shared/model/json-response.model';

@Injectable()
export class ScheduleDayHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/scheduledays`;
    }

    getAll(projectId): Promise<ScheduleDaySummary[]> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullScheduleDay>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<ScheduleDaySummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(scheduleDay: ScheduleDay): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(scheduleDay, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}