import { Component, Input } from '@angular/core';
import { SceneText, BaseSceneComponent } from '../../../../../..';

@Component({
  selector: 'screenplay-text',
  templateUrl: 'script-text.component.html',
})
export class ScriptTextComponent {
  @Input() public sceneTexts: SceneText[];
  @Input() public projectId: number;

  public getSceneComponents(scene: SceneText) {
    return (scene.actions as BaseSceneComponent[]).concat(scene.dialogues)
      .sort((a: BaseSceneComponent, b: BaseSceneComponent) => a.order - b.order);
  }
}
