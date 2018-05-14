import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CalendarEvent } from 'angular-calendar';
import { RouteInfo } from '../../shared/model/route-info.model';
import { EntityType } from '../../shared/enums/entity-type.enum';
import { CalendarHelpers } from '../../calendar/helpers/calendar.helpers';
import { CalendarItem } from '../../calendar/model/calendar-item';
import { CalendarHttpService } from '../../calendar/service/calendar-http.service';
import { LoadingWrapperService } from '../../shared/service/loading-wrapper.service';

@Component({
  selector: 'dashboard-calendar',
  templateUrl: 'dashboard-calendar.component.html',
})
export class DashboardCalendarComponent {
    public events: Array<CalendarEvent<{ routeInfo: RouteInfo }>> =
        new Array<CalendarEvent<{routeInfo: RouteInfo}>>();

    constructor(
      private _router: Router,
      private _calendarHttpService: CalendarHttpService,
      private _loadingWrapperService: LoadingWrapperService
    ) {}

    public getCalendarItems(dates: {start: Date, end: Date}) {
      this._loadingWrapperService.Load(
        this._calendarHttpService.getCalendarItems(dates.start, dates.end),
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
