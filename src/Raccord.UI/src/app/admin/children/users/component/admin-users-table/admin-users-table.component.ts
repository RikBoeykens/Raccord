import { Component, Input, Output, EventEmitter } from '@angular/core';
import { AdminUserSummary } from '../../../..';

@Component({
  selector: 'admin-users-table',
  templateUrl: 'admin-users-table.component.html',
})
export class AdminUsersTableComponent {
  @Input() public users: AdminUserSummary[];
  public displayedColumns = ['image', 'fullname', 'email', 'projectcount'];

  public getFullName(user: AdminUserSummary) {
    return `${user.firstName} ${user.lastName}`;
  }
}
