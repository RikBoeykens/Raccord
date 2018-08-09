import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../../../shared';
import { LocationSummary } from '../../../../../..';

@Component({
  templateUrl: 'locations-list.component.html'
})
export class LocationsListComponent implements OnInit {
  public locations: LocationSummary[];
  public project: ProjectSummary;
  public backEntity: string;

  constructor(
      private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        locations: LocationSummary[]
      }) => {
          this.locations = data.locations;
      });
      this.backEntity = this._route.snapshot.queryParams['src'] || '';
      this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.LOCATIONSDASHBOARD}`;
  }

  public getLocationLink(location: LocationSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.LOCATIONS}/${location.id}`;
  }
}
