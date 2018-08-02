import { Component, Input } from '@angular/core';
import { ScriptLocationSummary } from '../../model/script-location-summary.model';

@Component({
    selector: 'scrpt-location-avatar',
    templateUrl: 'script-location-avatar.component.html'
})
export class ScriptLocationAvatarComponent {

    @Input() public scriptLocation: ScriptLocationSummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
