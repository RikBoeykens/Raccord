import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SlateSummary } from '../../../../..';
import { ProjectSummary } from '../../../../../../shared/children/projects';
import { ProjectHelpers } from '../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../../shared';

@Component({
  templateUrl: 'slates-list.component.html'
})
export class SlatesListComponent implements OnInit {
  public slates: SlateSummary[];
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        slates: SlateSummary[]
      }) => {
          this.slates = data.slates;
      });
      this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}`;
  }

  public getSlateLink(slate: SlateSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SLATES}/${slate.id}`;
  }
}
