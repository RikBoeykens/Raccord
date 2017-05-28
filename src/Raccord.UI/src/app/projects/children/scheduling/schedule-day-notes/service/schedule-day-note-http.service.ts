import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullScheduleDayNote } from '../model/full-schedule-day-note.model';
import { ScheduleDayNoteSummary } from '../model/schedule-day-note-summary.model';
import { ScheduleDayNote } from '../model/schedule-day-note.model';
import { JsonResponse } from '../../../../../shared/model/json-response.model';

@Injectable()
export class ScheduleDayNoteHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/scheduledaynotes`;
    }

    getAll(projectId): Promise<ScheduleDayNoteSummary[]> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullScheduleDayNote>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<ScheduleDayNoteSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(scheduleDayNote: ScheduleDayNote): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(scheduleDayNote, uri);
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