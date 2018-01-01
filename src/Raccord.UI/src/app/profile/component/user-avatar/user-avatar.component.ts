import { Component, Input } from '@angular/core';
import { UserProfileSummary } from '../../model/user-profile-summary.model';

@Component({
    selector: 'user-avatar',
    templateUrl: 'user-avatar.component.html'
})
export class UserAvatarComponent{

    @Input() user: UserProfileSummary;

    getUserName(): string {
        return `${this.user.firstName} ${this.user.lastName}`;
    }
}