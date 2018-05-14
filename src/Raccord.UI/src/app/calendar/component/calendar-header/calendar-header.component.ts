import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'calendar-header',
  templateUrl: 'calendar-header.component.html',
})
export class CalendarHeaderComponent {
  @Input() public view: string;
  @Input() public viewDate: Date;
  @Output() public viewChange: EventEmitter<string> = new EventEmitter();
  @Output() public viewDateChange: EventEmitter<Date> = new EventEmitter();
}
