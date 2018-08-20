import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ScriptLocationSummary } from '../../../../../../../shared/children/script-locations';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import { ScriptLocationHttpService } from '../../../../../..';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  templateUrl: 'script-locations-list.component.html'
})
export class ScriptLocationsListComponent implements OnInit {
  public scriptLocations: ScriptLocationSummary[];
  public project: ProjectSummary;
  public backEntity: string;

  constructor(
      private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        scriptLocations: ScriptLocationSummary[]
      }) => {
          this.scriptLocations = data.scriptLocations;
      });
      this.backEntity = this._route.snapshot.queryParams['src'] || '';
      this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    if (this.backEntity === 'location') {
      return this.getLocationsDashboardLink();
    }
    return this.getScriptLink();
  }

  public getScriptLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCRIPT}`;
  }

  public getLocationsDashboardLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.LOCATIONSDASHBOARD}`;
  }

  public getScriptLocationLink(scriptLocation: ScriptLocationSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCRIPTLOCATIONS}/${scriptLocation.id}`;
  }
}
