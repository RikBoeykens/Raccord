import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ScheduleCrewUnitSummary } from '../../../../../..';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import { PagedData } from '../../../../../../../shared/children/paging';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  templateUrl: 'schedules-list.component.html'
})
export class SchedulesListComponent implements OnInit {
  public schedules: PagedData<ScheduleCrewUnitSummary>;
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        schedules: PagedData<ScheduleCrewUnitSummary>
      }) => {
          this.schedules = data.schedules;
      });
      this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCHEDULING}`;
  }

  public getScheduleLink(schedule: ScheduleCrewUnitSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCHEDULES}/${schedule.crewUnit.id}`;
  }
}
