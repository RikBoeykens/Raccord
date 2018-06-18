import { Component, Input } from '@angular/core';
import { UserProfileSummary } from '../../..';

@Component({
    selector: 'user-avatar',
    templateUrl: 'user-avatar.component.html'
})
export class UserAvatarComponent {

    @Input() public user: UserProfileSummary;
    @Input() public userId: string;
    @Input() public fullName: string;
    @Input() public hasImage: boolean;

    public getUserName(): string {
        if (!this.noUserDefined()) {
            return `${this.user.firstName} ${this.user.lastName}`;
        }
        return this.fullName;
    }

    public getHasImage(): boolean {
        if (!this.noUserDefined()) {
            return this.user.hasImage;
        }
        return this.hasImage;
    }

    private noUserDefined(): boolean {
        return this.user === null || typeof this.user === 'undefined';
    }
}
