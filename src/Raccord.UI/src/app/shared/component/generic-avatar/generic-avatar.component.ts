import { Component, Input } from '@angular/core';
import { Image } from '../../children/images/model/image.model';

@Component({
    selector: 'generic-avatar',
    templateUrl: 'generic-avatar.component.html'
})
export class GenericAvatarComponent {
    @Input() public image: Image;
    @Input() public title: string;
    @Input() public overridePlaceHolderText: string;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
