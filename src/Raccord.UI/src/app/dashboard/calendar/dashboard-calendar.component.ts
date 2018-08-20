import { Component } from '@angular/core';
import { CalendarEvent } from 'angular-calendar';
import { RouteInfo } from '../../shared';
import { LoadingWrapperService } from '../../shared/service/loading-wrapper.service';
import { CalendarHttpService } from '../../calendar/service/calendar-http.service';
import { CalendarItem, CalendarHelpers } from '../../calendar';

@Component({
  selector: 'dashboard-calendar',
  templateUrl: 'dashboard-calendar.component.html',
})
export class DashboardCalendarComponent {
    public events: Array<CalendarEvent<{ routeInfo: RouteInfo }>> =
        new Array<CalendarEvent<{routeInfo: RouteInfo}>>();

    constructor(
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
