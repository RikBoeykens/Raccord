import { Component, Input } from '@angular/core';
import { ScheduleSummary } from '../../../../../..';

@Component({
    selector: 'schedule-avatar',
    templateUrl: 'schedule-avatar.component.html'
})
export class ScheduleAvatarComponent {

    @Input() public schedule: ScheduleSummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
