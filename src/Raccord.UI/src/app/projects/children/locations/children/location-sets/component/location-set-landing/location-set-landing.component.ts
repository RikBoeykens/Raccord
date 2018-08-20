import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullLocationSet, Comment } from '../../../../../..';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings, ParentCommentType } from '../../../../../../../shared';
import { AccountHelpers } from '../../../../../../../shared/children/account';
import { ProjectPermissionEnum } from '../../../../../../../shared/children/users';

@Component({
  templateUrl: 'location-set-landing.component.html',
})
export class LocationSetLandingComponent implements OnInit {

  public locationSet: FullLocationSet;
  public project: ProjectSummary;
  public backEntity: string;

  constructor(
      private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { locationSet: FullLocationSet }) => {
      this.locationSet = data.locationSet;
    });
    this.project = ProjectHelpers.getCurrentProject();
    this.backEntity = this._route.snapshot.queryParams['src'] || '';
  }

  public getBackLink() {
    if (this.backEntity === 'scriptlocation') {
      return this.getScriptLocationLink();
    }
    return this.getLocationLink();
  }

  public getLocationLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.LOCATIONS}/${this.locationSet.location.id}`;
  }

  public getScriptLocationLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCRIPTLOCATIONS}/${this.locationSet.scriptLocation.id}`;
  }

  public getCanComment() {
    return AccountHelpers.hasProjectPermission(
        this.project.id,
        ProjectPermissionEnum.CanComment
    );
  }

  public getParentCommentType() {
    return ParentCommentType.locationSet;
  }

  public getCommentCount() {
    let total = 0;
    this.locationSet.comments.forEach((comment: Comment) => total += comment.commentCount);
    return total;
  }
}
