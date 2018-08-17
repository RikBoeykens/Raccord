import { Component, Input } from '@angular/core';
import { SlateSummary } from '../../model/slate-summary.model';

@Component({
    selector: 'slate-avatar',
    templateUrl: 'slate-avatar.component.html'
})
export class SlateAvatarComponent {

    @Input() public slate: SlateSummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
