import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedData } from '../../../../../shared/children/paging';
import { SceneSummary } from '../../../../../shared/children/scenes';
import { CharacterSummary } from '../../../../../shared/children/characters';
import { ScriptLocationSummary } from '../../../../../shared/children/script-locations';
import { ScriptDashboard } from '../../model/script-dashboard.model';
import { RouteSettings } from '../../../../../shared';
import { ProjectSummary } from '../../../../../shared/children/projects';
import { ProjectHelpers } from '../../../../../shared/children/projects/helpers/project.helpers';

@Component({
  templateUrl: 'script-dashboard.component.html'
})
export class ScriptDashboardComponent implements OnInit {
  public project: ProjectSummary;
  public scenes: PagedData<SceneSummary>;
  public characters: PagedData<CharacterSummary>;
  public scriptLocations: PagedData<ScriptLocationSummary>;
  constructor(
    private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
    this._route.data.subscribe((data: {dashboardInfo: ScriptDashboard}) => {
      this.scenes = data.dashboardInfo.scenes;
      this.characters = data.dashboardInfo.characters;
      this.scriptLocations = data.dashboardInfo.scriptLocations;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}`;
  }

  public getScenesLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCENES}`;
  }
}
