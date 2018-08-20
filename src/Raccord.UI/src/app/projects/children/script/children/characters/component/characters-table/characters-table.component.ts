import { Component, Input } from '@angular/core';
import { RouteSettings } from '../../../../../../../shared';
import { CharacterSummary } from '../../../../../../../shared/children/characters';

@Component({
  selector: 'characters-table',
  templateUrl: 'characters-table.component.html',
})
export class CharactersTableComponent {
  @Input() public characters: CharacterSummary[];
  @Input() public projectId: number;
  public displayedColumns = [
    'image',
    'number',
    'name'
  ];

  public getCharacterLink(character: CharacterSummary): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.CHARACTERS}/${character.id}`;
  }
}
