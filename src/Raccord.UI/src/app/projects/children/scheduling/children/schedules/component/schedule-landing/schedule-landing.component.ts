import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullScheduleDay, ScheduleSceneScene } from '../../../../../..';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import { CrewUnitSummary } from '../../../../../../../shared/children/crew';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  templateUrl: 'schedule-landing.component.html'
})
export class ScheduleLandingComponent implements OnInit {
  public scheduleDays: FullScheduleDay[];
  public crewUnit: CrewUnitSummary;
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        scheduleDays: FullScheduleDay[],
        crewUnit: CrewUnitSummary
      }) => {
          this.scheduleDays = data.scheduleDays;
          this.crewUnit = data.crewUnit;
      });
      this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCHEDULES}`;
  }

  public getFirstDay() {
    if (this.scheduleDays && this.scheduleDays.length) {
      return this.scheduleDays[0];
    }
    return null;
  }

  public getLastDay() {
    if (this.scheduleDays && this.scheduleDays.length) {
      return this.scheduleDays[this.scheduleDays.length - 1];
    }
    return null;
  }

  public getPageLength(scheduleDay: FullScheduleDay) {
    let result = 0;
    scheduleDay.scenes.forEach((scheduleScene: ScheduleSceneScene) => {
      result += scheduleScene.pageLength;
    });
    return result;
  }
}
