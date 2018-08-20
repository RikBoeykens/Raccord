import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FullCastMember, Comment } from '../../../../../..';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  templateUrl: 'cast-member-landing.component.html',
})
export class CastMemberLandingComponent implements OnInit {

  public castMember: FullCastMember;
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { castMember: FullCastMember }) => {
      this.castMember = data.castMember;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CAST}`;
  }

  public getFullName() {
    return `${this.castMember.firstName} ${this.castMember.lastName}`;
  }
}
