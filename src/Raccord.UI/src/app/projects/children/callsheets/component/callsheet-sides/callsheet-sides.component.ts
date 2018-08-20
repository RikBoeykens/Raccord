import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CallsheetSummary } from '../../model/callsheet-summary.model';
import { SceneText } from '../../../..';
import { ProjectSummary } from '../../../../../shared/children/projects';
import { ProjectHelpers } from '../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../shared';

@Component({
  templateUrl: 'callsheet-sides.component.html',
})
export class CallsheetSidesComponent implements OnInit {

  public sceneTexts: SceneText[];
  public project: ProjectSummary;
  public callsheet: CallsheetSummary;

  constructor(
      private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { sceneTexts: SceneText[], callsheet: CallsheetSummary }) => {
      this.sceneTexts = data.sceneTexts;
      this.callsheet = data.callsheet;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CALLSHEETS}/${this.callsheet.id}`;
  }
}
