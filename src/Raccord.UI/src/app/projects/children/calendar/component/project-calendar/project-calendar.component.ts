import { Component, Input } from '@angular/core';
import { CalendarEvent } from 'angular-calendar';
import { RouteInfo } from '../../../../../shared';
import { ProjectCalendarHttpService } from '../../service/project-calendar-http.service';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { CalendarItem, CalendarHelpers } from '../../../../../calendar';

@Component({
  selector: 'project-calendar',
  templateUrl: 'project-calendar.component.html',
})
export class ProjectCalendarComponent {
  @Input() public projectId: number;
    public events: Array<CalendarEvent<{ routeInfo: RouteInfo }>> =
        new Array<CalendarEvent<{routeInfo: RouteInfo}>>();

    constructor(
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
