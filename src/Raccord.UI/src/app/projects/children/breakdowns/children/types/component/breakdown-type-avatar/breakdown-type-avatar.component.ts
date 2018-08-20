import { Component, Input } from '@angular/core';
import { BreakdownTypeSummary } from '../../../../../..';

@Component({
    selector: 'breakdown-type-avatar',
    templateUrl: 'breakdown-type-avatar.component.html'
})
export class BreakdownTypeAvatarComponent {

    @Input() public breakdownType: BreakdownTypeSummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
