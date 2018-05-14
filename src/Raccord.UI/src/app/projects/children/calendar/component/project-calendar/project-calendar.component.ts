import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { CalendarEvent } from 'angular-calendar';
import { RouteInfo } from '../../../../../shared/model/route-info.model';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { CalendarItem } from '../../../../../calendar/model/calendar-item';
import { CalendarHelpers } from '../../../../../calendar/helpers/calendar.helpers';
import { ProjectCalendarHttpService } from '../../service/project-calendar-http.service';

@Component({
  selector: 'project-calendar',
  templateUrl: 'project-calendar.component.html',
})
export class ProjectCalendarComponent {
  @Input() public projectId: number;
    public events: Array<CalendarEvent<{ routeInfo: RouteInfo }>> =
        new Array<CalendarEvent<{routeInfo: RouteInfo}>>();

    constructor(
      private _router: Router,
      private _projectCalendarHttpService: ProjectCalendarHttpService,
      private _loadingWrapperService: LoadingWrapperService
    ) {}

    public getCalendarItems(dates: {start: Date, end: Date}) {
      this._loadingWrapperService.Load(
        this._projectCalendarHttpService.getAll(this.projectId, dates.start, dates.end),
        (data) => this.setEvents(data)
      );
    }

    private setEvents(items: CalendarItem[]) {
      this.events = items.map((item: CalendarItem) => {
        return {
          title: item.label,
          start: new Date(item.date),
          color: CalendarHelpers.getColour(item.routeInfo.type),
          meta: { routeInfo: item.routeInfo }
        };
      });
    }
}
