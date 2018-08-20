import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../../../../shared/children/projects';
import {
  ProjectHelpers
} from '../../../../../../../shared/children/projects/helpers/project.helpers';
import { RouteSettings } from '../../../../../../../shared';
import { CharacterSummary } from '../../../../../../../shared/children/characters';

@Component({
  templateUrl: 'characters-list.component.html'
})
export class CharactersListComponent implements OnInit {
  public characters: CharacterSummary[];
  public project: ProjectSummary;
  public backEntity: string;

  constructor(
      private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: {
        characters: CharacterSummary[]
      }) => {
          this.characters = data.characters;
      });
      this.backEntity = this._route.snapshot.queryParams['src'] || '';
      this.project = ProjectHelpers.getCurrentProject();
  }

  public getBackLink() {
    if (this.backEntity === 'cast') {
      return this.getCastDashboardLink();
    }
    return this.getScriptLink();
  }

  public getScriptLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.SCRIPT}`;
  }

  public getCastDashboardLink() {
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CASTDASHBOARD}`;
  }

  public getCharacterLink(character: CharacterSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CHARACTERS}/${character.id}`;
  }
}
