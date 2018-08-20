import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullBreakdown, BreakdownTypeSummary } from '../../../..';
import { ProjectSummary } from '../../../../../shared/children/projects';
import { ProjectHelpers } from '../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../shared';

@Component({
  templateUrl: 'breakdown-landing.component.html'
})
export class BreakdownLandingComponent implements OnInit {
  public breakdown: FullBreakdown;
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        breakdown: FullBreakdown
      }) => {
          this.breakdown = data.breakdown;
      });
      this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.BREAKDOWNS}`;
  }

  public getBreakdownTypeLink(breakdownType: BreakdownTypeSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.BREAKDOWNS}/${this.breakdown.id}/${RouteSettings.BREAKDOWNTYPES}/${breakdownType.id}`;
  }
}
