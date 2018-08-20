import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SceneText } from '../../../../../..';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  templateUrl: 'script-text-landing.component.html',
})
export class ScriptTextLandingComponent implements OnInit {

  public sceneTexts: SceneText[];
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { sceneTexts: SceneText[] }) => {
      this.sceneTexts = data.sceneTexts;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCRIPT}`;
  }
}
