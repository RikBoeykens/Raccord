import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
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
import { RouteInfo, RouteHelpers } from '../../../shared';

@Component({
  selector: 'calendar',
  templateUrl: 'calendar.component.html',
})
export class CalendarComponent implements OnInit {
    public view: string = 'week';
    public viewDate: Date = new Date();
    public activeDayIsOpen: boolean = false;
    @Input() public events: Array<CalendarEvent<{ routeInfo: RouteInfo }>> =
        new Array<CalendarEvent<{routeInfo: RouteInfo}>>();
    @Output() public dateChange: EventEmitter<{start: Date, end: Date}> = new EventEmitter();

    constructor(
      private _router: Router
    ) {}

    public ngOnInit() {
      this.getCalendarItems();
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
        const routeArray = RouteHelpers.getRouteArray(event.meta.routeInfo);
        this._router.navigate(routeArray);
    }

    public getCalendarItems() {
      const getStart: any = {
        month: startOfMonth,
        week: startOfWeek,
        day: startOfDay
      }[this.view];

      const getEnd: any = {
        month: endOfMonth,
        week: endOfWeek,
        day: endOfDay
      }[this.view];

      const dates = {start: getStart(this.viewDate), end: getEnd(this.viewDate)};
      this.dateChange.emit(dates);
    }
}
