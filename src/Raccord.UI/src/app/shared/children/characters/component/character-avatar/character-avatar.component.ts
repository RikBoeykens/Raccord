import { Component, Input } from '@angular/core';
import { CharacterSummary } from '../../model/character-summary.model';

@Component({
    selector: 'character-avatar',
    templateUrl: 'character-avatar.component.html'
})
export class CharacterAvatarComponent {

    @Input() public character: CharacterSummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
