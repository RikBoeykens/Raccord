import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { JsonResponse } from '../../shared/model/json-response.model';
import { CalendarItem } from '../../calendar/model/calendar-item';

@Injectable()
export class CalendarHttpService extends BaseHttpService {

    constructor(protected _http: Http) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/calendar`;
    }

    public getCalendarItems(start: Date, end: Date): Promise<CalendarItem[]> {

        let uri = `${this._baseUri}/user?start=${start.toISOString()}&end=${end.toISOString()}`;

        return this.doGetArray(uri);
    }
}
