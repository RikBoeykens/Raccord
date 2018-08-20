import { Input, Component } from '@angular/core';
import { SceneSummary } from '../../model/scene-summary.model';

@Component({
  selector: 'scene-card',
  templateUrl: 'scene-card.component.html'
})
export class SceneCardComponent {
  @Input() public scene: SceneSummary;
}
