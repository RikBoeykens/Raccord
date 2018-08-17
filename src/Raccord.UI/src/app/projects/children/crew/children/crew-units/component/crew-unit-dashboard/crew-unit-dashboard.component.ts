import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import { PagedData } from '../../../../../../../shared/children/paging';
import { ScheduleSummary, CallsheetSummary, CrewUnitDashboard } from '../../../../../..';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../../../shared';
import { CrewUnit } from '../../../../../../../shared/children/crew';

@Component({
  templateUrl: 'crew-unit-dashboard.component.html'
})
export class CrewUnitDashboardComponent implements OnInit {
  public project: ProjectSummary;
  public crewUnit: CrewUnit;
  public schedules: PagedData<ScheduleSummary>;
  public callsheets: PagedData<CallsheetSummary>;
  constructor(
    private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
    this._route.data.subscribe((data: {dashboardInfo: CrewUnitDashboard}) => {
      this.crewUnit = data.dashboardInfo.crewUnit;
      this.schedules = data.dashboardInfo.schedules;
      this.callsheets = data.dashboardInfo.callsheets;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}`;
  }

  public getScheduleLink(schedule: ScheduleSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCHEDULES}/${this.crewUnit.id}`;
  }

  public getCallsheetLink(callsheet: CallsheetSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CALLSHEETS}/${callsheet.id}`;
  }

  public getUnitListLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.UNITLISTS}/${this.crewUnit.id}`;
  }
}
