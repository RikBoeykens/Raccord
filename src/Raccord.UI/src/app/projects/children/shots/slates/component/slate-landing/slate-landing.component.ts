import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullSlate, Comment, Take } from '../../../../..';
import { ProjectSummary } from '../../../../../../shared/children/projects';
import { ProjectHelpers } from '../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings, ParentCommentType } from '../../../../../../shared';
import { AccountHelpers } from '../../../../../../shared/children/account';
import { ProjectPermissionEnum } from '../../../../../../shared/children/users';

@Component({
  templateUrl: 'slate-landing.component.html',
})
export class SlateLandingComponent implements OnInit {

  public slate: FullSlate;
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { slate: FullSlate }) => {
      this.slate = data.slate;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SLATES}`;
  }

  public getShootingDayLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SHOOTINGDAYS}/${this.slate.shootingDay.id}`;
  }

  public getSceneLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCENES}/${this.slate.scene.id}`;
  }

  public getCanComment() {
    return AccountHelpers.hasProjectPermission(
        this.project.id,
        ProjectPermissionEnum.CanComment
    );
  }

  public getParentCommentType() {
    return ParentCommentType.slate;
  }

  public getCommentCount() {
    let total = 0;
    this.slate.comments.forEach((comment: Comment) => total += comment.commentCount);
    return total;
  }

  public getCameraRolls() {
    if (!this.slate || !this.slate.takes) {
      return '';
    }
    const rolls = [];
    let currentRoll = this.slate.takes[0].cameraRoll;
    this.slate.takes.forEach((take: Take) => {
      if (currentRoll !== take.cameraRoll) {
        rolls.push(currentRoll);
        currentRoll = take.cameraRoll;
      }
    });
    rolls.push(currentRoll);
    return rolls.join(',');
  }

  public getSoundRolls() {
    if (!this.slate || !this.slate.takes) {
      return '';
    }
    const rolls = [];
    let currentRoll = this.slate.takes[0].soundRoll;
    this.slate.takes.forEach((take: Take) => {
      if (currentRoll !== take.soundRoll) {
        rolls.push(currentRoll);
        currentRoll = take.soundRoll;
      }
    });
    rolls.push(currentRoll);
    return rolls.join(',');
  }
}
