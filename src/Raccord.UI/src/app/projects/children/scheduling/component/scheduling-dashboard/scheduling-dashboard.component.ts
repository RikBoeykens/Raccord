import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedData } from '../../../../../shared/children/paging';
import { SchedulingDashboard } from '../../model/scheduling-dashboard.model';
import { RouteSettings } from '../../../../../shared';
import { ProjectSummary } from '../../../../../shared/children/projects';
import { ProjectHelpers } from '../../../../../shared/children/projects/helpers/project.helpers';
import { ScheduleSummary, CallsheetSummary } from '../../../..';

@Component({
  templateUrl: 'scheduling-dashboard.component.html'
})
export class SchedulingDashboardComponent implements OnInit {
  public project: ProjectSummary;
  public schedules: PagedData<ScheduleSummary>;
  public callsheets: PagedData<CallsheetSummary>;
  constructor(
    private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
    this._route.data.subscribe((data: {dashboardInfo: SchedulingDashboard}) => {
      this.schedules = data.dashboardInfo.schedules;
      this.callsheets = data.dashboardInfo.callsheets;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}`;
  }

  public getSchedulesLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCHEDULES}`;
  }

  public getScheduleLink(schedule: ScheduleSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCHEDULES}/${schedule.crewUnit.id}`;
  }

  public getCallsheetsLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CALLSHEETS}`;
  }

  public getCallsheetLink(callsheet: CallsheetSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CALLSHEETS}/${callsheet.id}`;
  }
}
