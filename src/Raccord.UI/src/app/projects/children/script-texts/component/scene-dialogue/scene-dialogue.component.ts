import { Component, Input } from "@angular/core";
import { SceneDialogue } from "../../model/scene-dialogue.model";

@Component({
  selector: 'scene-dialogue',
  templateUrl: 'scene-dialogue.component.html'
})
export class SceneDialogueComponent{

  @Input() sceneDialogue: SceneDialogue;
  @Input() projectID: number;

  constructor(
  ){
  }
}