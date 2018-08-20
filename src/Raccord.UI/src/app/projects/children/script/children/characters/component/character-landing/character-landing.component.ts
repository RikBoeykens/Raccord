import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullCharacter, Comment } from '../../../../../..';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { AccountHelpers } from '../../../../../../../shared/children/account';
import { ProjectPermissionEnum } from '../../../../../../../shared/children/users';
import { ParentCommentType, RouteSettings } from '../../../../../../../shared';

@Component({
  templateUrl: 'character-landing.component.html',
})
export class CharacterLandingComponent implements OnInit {

  public character: FullCharacter;
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { character: FullCharacter }) => {
      this.character = data.character;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CHARACTERS}`;
  }

  public getCanComment() {
    return AccountHelpers.hasProjectPermission(
        this.project.id,
        ProjectPermissionEnum.CanComment
    );
  }

  public getParentCommentType() {
    return ParentCommentType.character;
  }

  public getCommentCount() {
    let total = 0;
    this.character.comments.forEach((comment: Comment) => total += comment.commentCount);
    return total;
  }
}
