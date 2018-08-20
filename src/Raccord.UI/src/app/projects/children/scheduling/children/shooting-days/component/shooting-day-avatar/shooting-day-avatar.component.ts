import { Component, Input } from '@angular/core';
import { ShootingDaySummary } from '../../../../../..';

@Component({
    selector: 'shooting-day-avatar',
    templateUrl: 'shooting-day-avatar.component.html'
})
export class ShootingDayAvatarComponent {

    @Input() public shootingDay: ShootingDaySummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
