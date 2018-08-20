import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullLocation, Comment } from '../../../../../..';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { AccountHelpers } from '../../../../../../../shared/children/account';
import { ProjectPermissionEnum } from '../../../../../../../shared/children/users';
import { ParentCommentType, RouteSettings } from '../../../../../../../shared';

@Component({
  templateUrl: 'location-landing.component.html',
})
export class LocationLandingComponent implements OnInit {

  public location: FullLocation;
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { location: FullLocation }) => {
      this.location = data.location;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.LOCATIONS}`;
  }

  public getCanComment() {
    return AccountHelpers.hasProjectPermission(
        this.project.id,
        ProjectPermissionEnum.CanComment
    );
  }

  public getParentCommentType() {
    return ParentCommentType.location;
  }

  public getCommentCount() {
    let total = 0;
    this.location.comments.forEach((comment: Comment) => total += comment.commentCount);
    return total;
  }
}
