import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {
    BaseProjectHttpService
} from '../../../../../../../shared/service/base-project-http.service';
import {
    FullScheduleDay, FullScheduleDayCrewUnit, ScheduleDaySummary, ScheduleDay
} from '../../../../../../..';

@Injectable()
export class ScheduleDayHttpService extends BaseProjectHttpService {

    constructor(protected _http: HttpClient) {
        super(_http, 'scheduledays');
    }

    public getAll(authProjectId: number, crewUnitId: number): Promise<FullScheduleDay[] | void> {

        const uri = `${this.getUri(authProjectId)}/${crewUnitId}/crewunit`;

        return this.doGetArray(uri);
    }

    public getAllUser(authProjectId: number): Promise<FullScheduleDayCrewUnit[] | void> {

        const uri = `${this.getUri(authProjectId)}/user`;

        return this.doGetArray(uri);
    }

    public get(authProjectId: number, id: number): Promise<FullScheduleDay | void> {

        const uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(authProjectId: number, id: number): Promise<ScheduleDaySummary | void> {

        const uri = `${this.getUri(authProjectId)}/${id}/summary`;

        return this.doGet(uri);
    }

    public post(authProjectId: number, scheduleDay: ScheduleDay): Promise<number> {
        const uri = this.getUri(authProjectId);

        return this.doPost(scheduleDay, uri);
    }

    public delete(authProjectId: number, id: number): Promise<any> {
        const uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doDelete(uri);
    }

    public publish(authProjectId: number): Promise<any> {
        const uri = `${this.getUri(authProjectId)}/publish`;

        return this.doPost(null, uri);
    }
}
