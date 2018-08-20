import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullBreakdownType, BreakdownItemSummary } from '../../../../../..';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  templateUrl: 'breakdown-type-landing.component.html'
})
export class BreakdownTypeLandingComponent implements OnInit {
  public breakdownType: FullBreakdownType;
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        breakdownType: FullBreakdownType
      }) => {
          this.breakdownType = data.breakdownType;
      });
      this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.BREAKDOWNS}/${this.breakdownType.breakdown.id}`;
  }

  public getBackLinkText() {
    return `back to ${this.breakdownType.breakdown.name}`;
  }

  public getBreakdownItemLink(breakdownItem: BreakdownItemSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.BREAKDOWNS}/${this.breakdownType.breakdown.id}/${RouteSettings.BREAKDOWNITEMS}/${breakdownItem.id}`;
  }
}
