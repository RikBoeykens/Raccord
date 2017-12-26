import { Component, Input } from "@angular/core";
import { Scene } from "../../model/scene.model";

@Component({
  selector: 'scene-summary',
  templateUrl: 'scene-summary.component.html'
})
export class SceneSummaryComponent{

  @Input() scene: Scene;

  constructor(
  ){
  }
}