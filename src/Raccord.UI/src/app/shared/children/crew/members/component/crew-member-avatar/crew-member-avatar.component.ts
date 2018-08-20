import { Component, Input } from '@angular/core';
import { CrewMemberSummary } from '../../..';

@Component({
    selector: 'crew-member-avatar',
    templateUrl: 'crew-member-avatar.component.html'
})
export class CrewMemberAvatarComponent {

    @Input() public crewMember: CrewMemberSummary;
    @Input() public hasImage: boolean;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;

    public getFullName(): string {
        return `${this.crewMember.firstName} ${this.crewMember.lastName}`;
    }
}
