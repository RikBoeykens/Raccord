import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullScheduleDay } from '../model/full-schedule-day.model';
import { ScheduleDaySummary } from '../model/schedule-day-summary.model';
import { ScheduleDay } from '../model/schedule-day.model';
import { JsonResponse } from '../../../../../shared/model/json-response.model';
import { BaseProjectHttpService } from '../../../../shared/service/base-project-http.service';
import { FullScheduleDayCrewUnit } from '../model/full-schedule-day-crew-unit.model';
import { AuthService } from '../../../../../security/service/auth.service';

@Injectable()
export class ScheduleDayHttpService extends BaseProjectHttpService {

    constructor(protected _http: HttpClient) {
        super(_http, 'scheduledays');
    }

    public getAll(authProjectId: number, crewUnitId: number): Promise<FullScheduleDay[] | void> {

        let uri = `${this.getUri(authProjectId)}/${crewUnitId}/crewunit`;

        return this.doGetArray(uri);
    }

    public getAllUser(authProjectId: number): Promise<FullScheduleDayCrewUnit[] | void> {

        let uri = `${this.getUri(authProjectId)}/user`;

        return this.doGetArray(uri);
    }

    public get(authProjectId: number, id: number): Promise<FullScheduleDay | void> {

        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(authProjectId: number, id: Number): Promise<ScheduleDaySummary | void> {

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
