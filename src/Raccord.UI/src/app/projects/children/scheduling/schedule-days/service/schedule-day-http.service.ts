import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullScheduleDay } from '../model/full-schedule-day.model';
import { ScheduleDaySummary } from '../model/schedule-day-summary.model';
import { ScheduleDay } from '../model/schedule-day.model';
import { JsonResponse } from '../../../../../shared/model/json-response.model';
import { BaseProjectHttpService } from '../../../../shared/service/base-project-http.service';

@Injectable()
export class ScheduleDayHttpService extends BaseProjectHttpService {

    constructor(protected _http: Http) {
        super(_http, 'scheduledays');
    }

    public getAll(authProjectId: number): Promise<FullScheduleDay[]> {

        let uri = `${this.getUri(authProjectId)}/project`;

        return this.doGetArray(uri);
    }

    public get(authProjectId: number, id: number): Promise<FullScheduleDay> {

        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(authProjectId: number, id: Number): Promise<ScheduleDaySummary> {

        let uri = `${this.getUri(authProjectId)}/${id}/summary`;

        return this.doGet(uri);
    }

    public post(authProjectId: number, scheduleDay: ScheduleDay): Promise<number> {
        let uri = this.getUri(authProjectId);

        return this.doPost(scheduleDay, uri);
    }

    public delete(authProjectId: number, id: Number): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doDelete(uri);
    }

    public publish(authProjectId: number): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/publish`;

        return this.doPost(null, uri);
    }
}
