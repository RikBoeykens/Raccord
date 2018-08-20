import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullBreakdownItem, Comment } from '../../../../../..';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings, ParentCommentType } from '../../../../../../../shared';
import { AccountHelpers } from '../../../../../../../shared/children/account';
import { ProjectPermissionEnum } from '../../../../../../../shared/children/users';

@Component({
  templateUrl: 'breakdown-item-landing.component.html'
})
export class BreakdownItemLandingComponent implements OnInit {
  public breakdownItem: FullBreakdownItem;
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        breakdownItem: FullBreakdownItem
      }) => {
          this.breakdownItem = data.breakdownItem;
      });
      this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.BREAKDOWNS}/${this.breakdownItem.breakdown.id}/${RouteSettings.BREAKDOWNTYPES}/${this.breakdownItem.type.id}`;
  }

  public getBackLinkText() {
    return `back to ${this.breakdownItem.type.name}`;
  }

  public getCanComment() {
    return AccountHelpers.hasProjectPermission(
        this.project.id,
        ProjectPermissionEnum.CanComment
    );
  }

  public getParentCommentType() {
    return ParentCommentType.breakdownItem;
  }

  public getCommentCount() {
    let total = 0;
    this.breakdownItem.comments.forEach((comment: Comment) => total += comment.commentCount);
    return total;
  }
}
