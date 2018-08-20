import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedData } from '../../../../../shared/children/paging';
import { CastDashboard } from '../../model/cast-dashboard.model';
import { RouteSettings } from '../../../../../shared';
import { ProjectSummary } from '../../../../../shared/children/projects';
import { ProjectHelpers } from '../../../../../shared/children/projects/helpers/project.helpers';
import { CastMemberSummary } from '../../../../../shared/children/cast';
import { CharacterSummary } from '../../../../../shared/children/characters';

@Component({
  templateUrl: 'cast-dashboard.component.html'
})
export class CastDashboardComponent implements OnInit {
  public project: ProjectSummary;
  public castMembers: PagedData<CastMemberSummary>;
  public characters: PagedData<CharacterSummary>;
  constructor(
    private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
    this._route.data.subscribe((data: {dashboardInfo: CastDashboard}) => {
      this.castMembers = data.dashboardInfo.castMembers;
      this.characters = data.dashboardInfo.characters;
    });
    this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}`;
  }

  public getCastMembersLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CAST}`;
  }

  public getCastMemberLink(castMember: CastMemberSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CAST}/${castMember.id}`;
  }

  public getCharactersLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CHARACTERS}`;
  }

  public getCharacterLink(character: CharacterSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CHARACTERS}/${character.id}`;
  }
}
