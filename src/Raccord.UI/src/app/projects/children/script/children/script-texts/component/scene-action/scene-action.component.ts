import { Component, Input } from '@angular/core';
import { SceneAction } from '../../../../../..';

@Component({
  selector: 'scene-action',
  templateUrl: 'scene-action.component.html'
})
export class SceneActionComponent {
  @Input() public sceneAction: SceneAction;
}
