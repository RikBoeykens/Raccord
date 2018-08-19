import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedData } from '../../../../../shared/children/paging';
import { SchedulingDashboard } from '../../model/scheduling-dashboard.model';
import { RouteSettings } from '../../../../../shared';
import { ProjectSummary } from '../../../../../shared/children/projects';
import { ProjectHelpers } from '../../../../../shared/children/projects/helpers/project.helpers';
import { ScheduleCrewUnitSummary, CallsheetCrewUnit, ShootingDayCrewUnit } from '../../../..';

@Component({
  templateUrl: 'scheduling-dashboard.component.html'
})
export class SchedulingDashboardComponent implements OnInit {
  public project: ProjectSummary;
  public schedules: PagedData<ScheduleCrewUnitSummary>;
  public callsheets: PagedData<CallsheetCrewUnit>;
  public shootingDays: PagedData<ShootingDayCrewUnit>;
  constructor(
    private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
    this._route.data.subscribe((data: {dashboardInfo: SchedulingDashboard}) => {
      this.schedules = data.dashboardInfo.schedules;
      this.callsheets = data.dashboardInfo.callsheets;
      this.shootingDays = data.dashboardInfo.shootingDays;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}`;
  }

  public getSchedulesLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCHEDULES}`;
  }

  public getScheduleLink(schedule: ScheduleCrewUnitSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCHEDULES}/${schedule.crewUnit.id}`;
  }

  public getCallsheetsLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CALLSHEETS}`;
  }

  public getCallsheetLink(callsheet: CallsheetCrewUnit) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CALLSHEETS}/${callsheet.id}`;
  }

  public getShootingDaysLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SHOOTINGDAYS}`;
  }

  public getShootingDayLink(shootingDay: ShootingDayCrewUnit) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SHOOTINGDAYS}/${shootingDay.id}`;
  }
}
