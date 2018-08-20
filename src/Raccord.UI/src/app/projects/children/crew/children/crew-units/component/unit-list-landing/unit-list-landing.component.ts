import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../../../shared';
import { CrewUnitSummary, FullCrewDepartment } from '../../../../../../../shared/children/crew';

@Component({
  templateUrl: 'unit-list-landing.component.html'
})
export class UnitListLandingComponent implements OnInit {
  public crewDepartments: FullCrewDepartment[];
  public crewUnit: CrewUnitSummary;
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        crewUnit: CrewUnitSummary,
        crewDepartments: FullCrewDepartment[]
      }) => {
          this.crewUnit = data.crewUnit;
          this.crewDepartments = data.crewDepartments;
      });
      this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CREW}/${this.crewUnit.id}`;
  }

  public getCrewCount(crewDepartment: FullCrewDepartment) {
    return crewDepartment.crewMembers.length;
  }
}
