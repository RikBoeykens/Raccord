import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../../../shared';
import { CastMemberSummary } from '../../../../../../../shared/children/cast';

@Component({
  templateUrl: 'cast-members-list.component.html'
})
export class CastMembersListComponent implements OnInit {
  public castMembers: CastMemberSummary[];
  public project: ProjectSummary;
  public backEntity: string;

  constructor(
      private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        castMembers: CastMemberSummary[]
      }) => {
          this.castMembers = data.castMembers;
      });
      this.backEntity = this._route.snapshot.queryParams['src'] || '';
      this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CASTDASHBOARD}`;
  }

  public getCastMemberLink(character: CastMemberSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CAST}/${character.id}`;
  }
}
