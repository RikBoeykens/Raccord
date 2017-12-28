import { Component, Input } from "@angular/core";
import { SceneText } from "../../model/scene-text.model";
import { BaseSceneComponent } from "../../model/base-scene-component.model";

@Component({
  selector: 'screenplay-text',
  templateUrl: 'script-text.component.html',
})
export class ScriptTextComponent {
  @Input() sceneTexts: SceneText[];
  @Input() projectID: number;

  public getSceneComponents(scene: SceneText) {
    return (<BaseSceneComponent[]> scene.actions).concat(scene.dialogues)
      .sort((a: BaseSceneComponent, b: BaseSceneComponent) => a.order - b.order);
  }
}
