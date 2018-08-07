import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullScriptLocation, Comment } from '../../../../../..';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { AccountHelpers } from '../../../../../../../shared/children/account';
import { ProjectPermissionEnum } from '../../../../../../../shared/children/users';
import { ParentCommentType, RouteSettings } from '../../../../../../../shared';

@Component({
  templateUrl: 'script-location-landing.component.html',
})
export class ScriptLocationLandingComponent implements OnInit {

  public scriptLocation: FullScriptLocation;
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { scriptLocation: FullScriptLocation }) => {
      this.scriptLocation = data.scriptLocation;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCRIPTLOCATIONS}`;
  }

  public getCanComment() {
    return AccountHelpers.hasProjectPermission(
        this.project.id,
        ProjectPermissionEnum.CanComment
    );
  }

  public getParentCommentType() {
    return ParentCommentType.scene;
  }

  public getCommentCount() {
    let total = 0;
    this.scriptLocation.comments.forEach((comment: Comment) => total += comment.commentCount);
    return total;
  }
}
