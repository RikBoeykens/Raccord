import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CallsheetCrewUnit } from '../../../..';
import { ProjectSummary } from '../../../../../shared/children/projects';
import { ProjectHelpers } from '../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../shared';

@Component({
  templateUrl: 'callsheets-list.component.html'
})
export class CallsheetsListComponent implements OnInit {
  public callsheets: CallsheetCrewUnit[];
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        callsheets: CallsheetCrewUnit[]
      }) => {
          this.callsheets = data.callsheets;
      });
      this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCHEDULING}`;
  }

  public getCallsheetLink(callsheet: CallsheetCrewUnit) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CALLSHEETS}/${callsheet.id}`;
  }
}
