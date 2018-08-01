import { Component, Input } from '@angular/core';
import { SceneDialogue } from '../../../../../..';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  selector: 'scene-dialogue',
  templateUrl: 'scene-dialogue.component.html'
})
export class SceneDialogueComponent {

  @Input() public sceneDialogue: SceneDialogue;
  @Input() public projectId: number;

  public getCharacterLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.CHARACTERS}/${this.sceneDialogue.character.id}`;
  }

}
