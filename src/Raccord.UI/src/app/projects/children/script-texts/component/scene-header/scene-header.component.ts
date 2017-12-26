import { Component, Input } from "@angular/core";
import { Scene } from "../../../scenes/model/scene.model";

@Component({
  selector: 'scene-header',
  templateUrl: 'scene-header.component.html'
})
export class SceneHeaderComponent{

  @Input() scene: Scene;
  @Input() projectID: number;

  constructor(
  ){
  }
}