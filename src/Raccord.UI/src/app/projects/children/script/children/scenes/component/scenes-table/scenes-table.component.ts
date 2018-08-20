import { Component, Input } from '@angular/core';
import { SceneSummary } from '../../../../../../../shared/children/scenes';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  selector: 'scenes-table',
  templateUrl: 'scenes-table.component.html',
})
export class ScenesTableComponent {
  @Input() public scenes: SceneSummary[];
  @Input() public projectId: number;
  public displayedColumns = [
    'image',
    'sceneIntro',
    'scriptLocation',
    'timeOfDay',
    'summary',
    'pageLength'
  ];

  public getSceneLink(scene: SceneSummary): string {
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.SCENES}/${scene.id}`;
  }
}
