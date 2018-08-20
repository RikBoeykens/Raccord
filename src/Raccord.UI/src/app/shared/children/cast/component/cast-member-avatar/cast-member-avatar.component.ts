import { Component, Input } from '@angular/core';
import { CastMemberSummary } from '../../model/cast-member-summary.model';

@Component({
    selector: 'cast-member-avatar',
    templateUrl: 'cast-member-avatar.component.html'
})
export class CastMemberAvatarComponent {

    @Input() public castMember: CastMemberSummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;

    public getFullName() {
        return `${this.castMember.firstName} ${this.castMember.lastName}`;
    }
}
