import { Component, Input, Output, EventEmitter } from '@angular/core';
import { AdminUserSummary } from '../../../..';
import { RouteSettings } from '../../../../../shared';

@Component({
  selector: 'admin-users-table',
  templateUrl: 'admin-users-table.component.html',
})
export class AdminUsersTableComponent {
  @Input() public users: AdminUserSummary[];
  @Output() public showConfirmRemove: EventEmitter<AdminUserSummary> = new EventEmitter();
  public displayedColumns = ['image', 'fullname', 'email', 'projectcount', 'options'];

  public getFullName(user: AdminUserSummary) {
    return `${user.firstName} ${user.lastName}`;
  }

  public getAdminUserLink(user: AdminUserSummary) {
    return `/${RouteSettings.ADMIN}/${RouteSettings.USERS}/${user.id}`;
  }

  public doShowConfirmRemove(user: AdminUserSummary) {
    this.showConfirmRemove.emit(user);
  }
}
