import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseProjectHttpService } from '../../../shared/service/base-project-http.service';
import { CalendarItem } from '../../../../calendar';

@Injectable()
export class ProjectCalendarHttpService extends BaseProjectHttpService {

  constructor(protected _http: HttpClient) {
      super(_http, 'calendar');
  }

  public getAll(authProjectId: number, start: Date, end: Date): Promise<CalendarItem[] | void> {

    const uri =
      `${this.getUri(authProjectId)}?start=${start.toISOString()}&end=${end.toISOString()}`;

    return this.doGetArray(uri);
  }
}
