import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullScene, Comment } from '../../../../../..';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { AccountHelpers } from '../../../../../../../shared/children/account';
import { ProjectPermissionEnum } from '../../../../../../../shared/children/users';
import { ParentCommentType, RouteSettings } from '../../../../../../../shared';

@Component({
  templateUrl: 'scene-landing.component.html',
})
export class SceneLandingComponent implements OnInit {

  public scene: FullScene;
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { scene: FullScene }) => {
      this.scene = data.scene;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCENES}`;
  }

  public getScriptLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCRIPTTEXT}`;
  }

  public getScriptLocationLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCRIPTLOCATIONS}/${this.scene.scriptLocation.id}`;
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
    this.scene.comments.forEach((comment: Comment) => total += comment.commentCount);
    return total;
  }
}
