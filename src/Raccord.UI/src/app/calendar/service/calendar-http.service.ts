import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { CalendarItem } from '../model/calendar-item';

@Injectable()
export class CalendarHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/calendar`;
    }

    public getCalendarItems(start: Date, end: Date): Promise<CalendarItem[] | void> {

        const uri = `${this._baseUri}/user?start=${start.toISOString()}&end=${end.toISOString()}`;

        return this.doGetArray(uri);
    }
}
