import { Component, Input } from '@angular/core';
import { BreakdownSummary } from '../../model/breakdown-summary.model';

@Component({
    selector: 'breakdown-avatar',
    templateUrl: 'breakdown-avatar.component.html'
})
export class BreakdownAvatarComponent {

    @Input() public breakdown: BreakdownSummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
