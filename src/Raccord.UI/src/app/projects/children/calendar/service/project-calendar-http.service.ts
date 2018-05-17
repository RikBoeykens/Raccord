import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { BaseProjectHttpService } from '../../../shared/service/base-project-http.service';
import { CalendarItem } from '../../../../calendar/model/calendar-item';
import { AuthService } from '../../../../security/service/auth.service';

@Injectable()
export class ProjectCalendarHttpService extends BaseProjectHttpService {

  constructor(protected _http: Http, protected _authService: AuthService) {
      super(_http, _authService, 'calendar');
  }

  public getAll(authProjectId: number, start: Date, end: Date): Promise<CalendarItem[]> {

    let uri = `${this.getUri(authProjectId)}?start=${start.toISOString()}&end=${end.toISOString()}`;

    return this.doGetArray(uri);
  }
}