import { Component, Input, Output, EventEmitter } from '@angular/core';
import { AdminUserInvitationSummary } from '../../../..';
import { RouteSettings } from '../../../../../shared';

@Component({
  selector: 'admin-user-invitations-table',
  templateUrl: 'admin-user-invitations-table.component.html',
})
export class AdminUserInvitationsTableComponent {
  @Input() public userInvitations: AdminUserInvitationSummary[];
  public displayedColumns = ['image', 'fullname', 'email', 'projectcount', 'accepted'];

  public getFullName(userInvitation: AdminUserInvitationSummary) {
    return `${userInvitation.firstName} ${userInvitation.lastName}`;
  }

  public getAdminUserInvitationLink(userInvitation: AdminUserInvitationSummary) {
    return `/${RouteSettings.ADMIN}/${RouteSettings.INVITATIONS}/${userInvitation.id}`;
  }
}
