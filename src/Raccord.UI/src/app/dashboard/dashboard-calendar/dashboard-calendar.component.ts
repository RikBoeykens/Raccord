import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CalendarEvent } from 'angular-calendar';
import {
    isSameMonth,
    isSameDay,
    startOfMonth,
    endOfMonth,
    startOfWeek,
    endOfWeek,
    startOfDay,
    endOfDay,
    format
  } from 'date-fns';
import { RouteInfo } from '../../shared/model/route-info.model';
import { EntityType } from '../../shared/enums/entity-type.enum';
import { RouteHelpers } from '../../shared/helpers/route.helpers';
import { CalendarHelpers } from '../../calendar/helpers/calendar.helpers';
import { CalendarHttpService } from '../../calendar';
import { CalendarItem } from '../../calendar/model/calendar-item';
import { LoadingWrapperService } from '../../shared';

@Component({
  selector: 'dashboard-calendar',
  templateUrl: 'dashboard-calendar.component.html',
})
export class DashboardCalendarComponent implements OnInit {
    public viewDate: Date = new Date();
    public activeDayIsOpen: boolean = false;
    public events: Array<CalendarEvent<{ routeInfo: RouteInfo }>> =
        new Array<CalendarEvent<{routeInfo: RouteInfo}>>();

    constructor(
      private _router: Router,
      private _calendarHttpService: CalendarHttpService,
      private _loadingWrapperService: LoadingWrapperService
    ) {}

    public ngOnInit() {
      this._loadingWrapperService.Load(
        this._calendarHttpService.getCalendarItems(new Date(2018, 4, 1), new Date(2018, 5, 1)),
        (data) => this.setEvents(data)
      );
    }

    public dayClicked({
        date,
        events
      }: {
        date: Date;
        events: Array<CalendarEvent<{ routeInfo: RouteInfo }>>;
      }): void {
        if (isSameMonth(date, this.viewDate)) {
          if (
            (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
            events.length === 0
          ) {
            this.activeDayIsOpen = false;
          } else {
            this.activeDayIsOpen = true;
            this.viewDate = date;
          }
        }
      }

    public eventClicked(event: CalendarEvent<{ routeInfo: RouteInfo }>): void {
        let routeArray = RouteHelpers.getRouteArray(event.meta.routeInfo);
        this._router.navigate(routeArray);
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
