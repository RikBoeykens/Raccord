import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CrewUnitSummary } from '../../../../../shared/children/crew';
import { ProjectSummary } from '../../../../../shared/children/projects';
import { ProjectHelpers } from '../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../shared';

@Component({
  templateUrl: 'crew-dashboard.component.html'
})
export class CrewDashboardComponent implements OnInit {
  public project: ProjectSummary;
  public crewUnits: CrewUnitSummary;
  constructor(
    private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
    this._route.data.subscribe((data: {crewUnits: CrewUnitSummary}) => {
      this.crewUnits = data.crewUnits;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}`;
  }

  public getCrewUnitLink(crewUnit: CrewUnitSummary) {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CREW}/${crewUnit.id}`;
  }
}
