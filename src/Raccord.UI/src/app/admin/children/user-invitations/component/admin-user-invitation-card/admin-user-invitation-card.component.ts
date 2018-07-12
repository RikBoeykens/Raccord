import { Input, Component } from '@angular/core';
import { AdminUserInvitationSummary } from '../../../..';

@Component({
  selector: 'admin-user-invitation-card',
  templateUrl: 'admin-user-invitation-card.component.html'
})
export class AdminUserInvitationCardComponent {
  @Input() public userInvitation: AdminUserInvitationSummary;

  public getFullName() {
    return `${this.userInvitation.firstName} ${this.userInvitation.lastName}`;
  }
}
