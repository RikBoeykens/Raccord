import { Component, Input } from '@angular/core';
import { RouteSettings } from '../../../../../../../shared';
import { CallsheetBreakdownType } from '../../../../../..';
import { CallsheetBreakdownItem } from '../../children/items/model/callsheet-breakdown-item.model';

@Component({
  selector: 'callsheet-breakdowns-table',
  templateUrl: 'callsheet-breakdowns-table.component.html',
})
export class CallsheetBreakdownsTableComponent {
  @Input() public callsheetBreakdownTypes: CallsheetBreakdownType[];
  @Input() public breakdownId: number;
  @Input() public projectId: number;

  public displayedColumns = ['type', 'scenes'];

  public getBreakdownTypeLink(type: CallsheetBreakdownType): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.BREAKDOWNS}/${this.breakdownId}/${RouteSettings.BREAKDOWNTYPES}/${type.id}`;
  }

  public getBreakdownItemLink(item: CallsheetBreakdownItem): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.BREAKDOWNITEMS}/${item.id}`;
  }
}
