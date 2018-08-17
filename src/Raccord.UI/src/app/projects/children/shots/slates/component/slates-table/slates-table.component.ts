import { Component, Input } from '@angular/core';
import { SlateSummary } from '../../../../..';
import { RouteSettings } from '../../../../../../shared';

@Component({
  selector: 'slates-table',
  templateUrl: 'slates-table.component.html',
})
export class SlatesTableComponent {
  @Input() public slates: SlateSummary[];
  @Input() public projectId: number;
  public displayedColumns = [
    'image',
    'number',
    'description'
  ];

  public getSlateLink(slate: SlateSummary): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.SLATES}/${slate.id}`;
  }
}
