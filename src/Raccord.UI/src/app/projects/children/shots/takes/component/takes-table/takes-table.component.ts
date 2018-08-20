import { Component, Input } from '@angular/core';
import { TakeSummary } from '../../model/take-summary.model';

@Component({
  selector: 'takes-table',
  templateUrl: 'takes-table.component.html',
})
export class TakesTableComponent {
  @Input() public takes: TakeSummary[];
  @Input() public projectId: number;
  public displayedColumns = [
    'selected',
    'number',
    'length',
    'notes'
  ];
}
