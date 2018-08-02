import { Component, Input } from '@angular/core';
import { Scene } from '../..';

@Component({
  selector: 'scene-summary',
  templateUrl: 'scene-summary.component.html'
})
export class SceneSummaryComponent {
  @Input() public scene: Scene;
  @Input() public showPageLength: boolean;
  @Input() public pageLengthOverride: number;
}
