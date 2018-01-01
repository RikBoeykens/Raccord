import { Component, Input } from '@angular/core';
import { UserProfileSummary } from '../../model/user-profile-summary.model';

@Component({
    selector: 'user-avatar',
    templateUrl: 'user-avatar.component.html'
})
export class UserAvatarComponent{

    @Input() user: UserProfileSummary;
    @Input() userId: string;
    @Input() fullName: string;
    @Input() hasImage: boolean;

    getUserName(): string {
        if (!this.noUserDefined()) {
            return `${this.user.firstName} ${this.user.lastName}`;
        }
        return this.fullName;
    }

    getHasImage(): boolean {
        if (!this.noUserDefined()) {
            return this.user.hasImage;
        }
        return this.hasImage;
    }

    private noUserDefined(): boolean {
        return this.user === null || typeof this.user === 'undefined';
    }
}