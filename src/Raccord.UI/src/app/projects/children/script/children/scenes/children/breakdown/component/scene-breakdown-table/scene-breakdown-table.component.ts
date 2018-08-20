import { Component, Input } from '@angular/core';
import { RouteSettings } from '../../../../../../../../../shared';
import {
  SceneBreakdown,
  SceneBreakdownItem,
  BreakdownType
} from '../../../../../../../..';

@Component({
  selector: 'scene-breakdown-table',
  templateUrl: 'scene-breakdown-table.component.html',
})
export class SceneBreakdownTableComponent {
  @Input() public sceneBreakdown: SceneBreakdown;
  @Input() public projectId: number;
  public displayedColumns = [
    'image',
    'type',
    'item'
  ];

  public getBreakdownItemLink(breakdownItem: SceneBreakdownItem): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.BREAKDOWNS}/${this.sceneBreakdown.id}/${RouteSettings.BREAKDOWNITEMS}/${breakdownItem.id}`;
  }

  public getBreakdownTypeLink(breakdownType: BreakdownType): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.BREAKDOWNS}/${this.sceneBreakdown.id}/${RouteSettings.BREAKDOWNTYPES}/${breakdownType.id}`;
  }
}
