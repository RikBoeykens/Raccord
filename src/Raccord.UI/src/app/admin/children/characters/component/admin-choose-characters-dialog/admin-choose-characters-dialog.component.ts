import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import {
  SearchResult
} from '../../../../../shared/children/search';
import { EntityType } from '../../../../../shared';
import { Character } from '../../../../../shared/children/characters';

@Component({
  templateUrl: 'admin-choose-characters-dialog.component.html',
})

export class AdminChooseCharactersDialogComponent {
  public title: string;
  public selectedCharacters: SearchResult[] = [];
  public projectId: number;
  public characterEntityType: EntityType = EntityType.character;

  constructor(
    private _dialogRef: MatDialogRef<AdminChooseCharactersDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      title: string,
      selectedCharacters: Character[],
      projectId: number
    }
  ) {
    this.title = data.title;
    this.selectedCharacters = data.selectedCharacters.map((character: Character) =>
      new SearchResult( {
        id: character.id,
        displayName: character.name,
        info: '',
        routeInfo: null
      }));
    this.projectId = data.projectId;
  }

  public submit() {
    this._dialogRef.close({
      characterIds: this.selectedCharacters.map((character: SearchResult) => character.id)
    });
  }

  public onSelect(searchResult: SearchResult) {
    this.selectedCharacters.push(searchResult);
  }

  public removeSelectedCharacter(searchResult: SearchResult) {
    const index = this.selectedCharacters.findIndex((character: SearchResult) =>
      character.id === searchResult.id);
    if (index > -1) {
      this.selectedCharacters.splice(index, 1);
    }
  }
}
