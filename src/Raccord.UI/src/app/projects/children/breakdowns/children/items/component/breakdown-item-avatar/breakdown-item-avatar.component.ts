import { Component, Input } from '@angular/core';
import { BreakdownItemSummary } from '../../model/breakdown-item-summary.model';

@Component({
    selector: 'breakdown-item-avatar',
    templateUrl: 'breakdown-item-avatar.component.html'
})
export class BreakdownItemAvatarComponent {

    @Input() public item: BreakdownItemSummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
