import { Component, Input } from '@angular/core';
import { CallsheetSummary } from '../../../..';

@Component({
    selector: 'callsheet-avatar',
    templateUrl: 'callsheet-avatar.component.html'
})
export class CallsheetAvatarComponent {

    @Input() public callsheet: CallsheetSummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
