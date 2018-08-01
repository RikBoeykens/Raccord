import { Component, Input } from '@angular/core';
import { SceneSummary } from '../../model/scene-summary.model';

@Component({
    selector: 'scene-avatar',
    templateUrl: 'scene-avatar.component.html'
})
export class SceneAvatarComponent {

    @Input() public scene: SceneSummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
