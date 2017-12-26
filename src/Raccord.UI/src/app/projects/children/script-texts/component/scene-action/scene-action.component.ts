import { Component, Input } from "@angular/core";
import { SceneAction } from "../../model/scene-action.model";

@Component({
  selector: 'scene-action',
  templateUrl: 'scene-action.component.html'
})
export class SceneActionComponent{

  @Input() sceneAction: SceneAction;

  constructor(
  ){
  }
}