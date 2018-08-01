import { Component, Input } from '@angular/core';
import { Scene } from '../../../../../../../shared/children/scenes';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  selector: 'scene-header',
  templateUrl: 'scene-header.component.html'
})
export class SceneHeaderComponent {

  @Input() public scene: Scene;
  @Input() public projectId: number;

  public getSceneLink() {
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.SCENES}/${this.scene.id}`;
  }
}
