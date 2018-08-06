import { Component, Input } from '@angular/core';
import { RouteSettings } from '../../../../../../../../../shared';
import { LinkedCharacter } from '../../../../../../../../../shared/children/characters';

@Component({
  selector: 'scene-characters-table',
  templateUrl: 'scene-characters-table.component.html',
})
export class SceneCharactersTableComponent {
  @Input() public characters: LinkedCharacter[];
  @Input() public projectId: number;
  public displayedColumns = [
    'image',
    'name'
  ];

  public getCharacterLink(character: LinkedCharacter): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.CHARACTERS}/${character.id}`;
  }
}
