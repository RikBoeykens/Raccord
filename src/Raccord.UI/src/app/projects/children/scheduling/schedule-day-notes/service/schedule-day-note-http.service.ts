import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullScheduleDayNote } from '../model/full-schedule-day-note.model';
import { ScheduleDayNoteSummary } from '../model/schedule-day-note-summary.model';
import { ScheduleDayNote } from '../model/schedule-day-note.model';
import { JsonResponse } from '../../../../../shared/model/json-response.model';
import { BaseProjectHttpService } from '../../../../shared/service/base-project-http.service';
import { AuthService } from '../../../../../security/service/auth.service';

@Injectable()
export class ScheduleDayNoteHttpService extends BaseProjectHttpService {

    constructor(protected _http: Http, protected _authService: AuthService) {
        super(_http, _authService, 'scheduledaynotes');
    }

    public getAll(authProjectId: number): Promise<ScheduleDayNoteSummary[]> {

        let uri = `${this.getUri(authProjectId)}/project`;

        return this.doGetArray(uri);
    }

    public get(authProjectId: number, id: number): Promise<FullScheduleDayNote> {

        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(authProjectId: number, id: Number): Promise<ScheduleDayNoteSummary> {

        let uri = `${this.getUri(authProjectId)}/${id}/summary`;

        return this.doGet(uri);
    }

    public post(authProjectId: number, scheduleDayNote: ScheduleDayNote): Promise<number> {
        let uri = this.getUri(authProjectId);

        return this.doPost(scheduleDayNote, uri);
    }

    public delete(authProjectId: number, id: Number): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doDelete(uri);
    }

    public merge(authProjectId: number, toId: Number, mergeId): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/merge/${toId}/${mergeId}`;

        return this.doPost(null, uri);
    }
}
