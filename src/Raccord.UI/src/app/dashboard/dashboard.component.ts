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
import { RouteInfo } from '../shared/model/route-info.model';
import { EntityType } from '../shared/enums/entity-type.enum';
import { RouteHelpers } from '../shared/helpers/route.helpers';

@Component({
    templateUrl: 'dashboard.component.html',
})
export class DashboardComponent implements OnInit {
    public viewDate: Date = new Date();
    public activeDayIsOpen: boolean = false;
    public events: Array<CalendarEvent<{ routeInfo: RouteInfo }>> =
        new Array<CalendarEvent<{routeInfo: RouteInfo}>>();

    constructor(private _router: Router) {}

    public ngOnInit() {
        let routeInfo = new RouteInfo({type: EntityType.project, routeIDs: [1]});
        this.events.push({
            title: 'Bla',
            start: new Date(),
            color: {
                primary: '#ad2121',
                secondary: '#FAE3E3'
            },
            meta: { routeInfo }
        });
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
}
