import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedData } from '../../../../../shared/children/paging';
import { SceneSummary } from '../../../../../shared/children/scenes';
import { CharacterSummary } from '../../../../../shared/children/characters';
import { ScriptLocationSummary } from '../../../../../shared/children/script-locations';
import { LocationDashboard } from '../../model/location-dashboard.model';
import { RouteSettings } from '../../../../../shared';
import { ProjectSummary } from '../../../../../shared/children/projects';
import { ProjectHelpers } from '../../../../../shared/children/projects/helpers/project.helpers';
import { LocationSummary } from '../../children/locations/model/location-summary.model';

@Component({
  templateUrl: 'location-dashboard.component.html'
})
export class LocationDashboardComponent implements OnInit {
  public project: ProjectSummary;
  public locations: PagedData<LocationSummary>;
  public scriptLocations: PagedData<ScriptLocationSummary>;
  constructor(
    private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
    this._route.data.subscribe((data: {dashboardInfo: LocationDashboard}) => {
      this.locations = data.dashboardInfo.locations;
      this.scriptLocations = data.dashboardInfo.scriptLocations;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}`;
  }

  public getLocationsLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.LOCATIONS}`;
  }

  public getLocationLink(location: LocationSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.LOCATIONS}/${location.id}`;
  }

  public getScriptLocationsLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCRIPTLOCATIONS}`;
  }

  public getScriptLocationLink(scriptLocation: ScriptLocationSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCRIPTLOCATIONS}/${scriptLocation.id}`;
  }
}
