import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ProjectUserUser } from '../../../../../shared/children/users';

@Component({
  selector: 'admin-project-project-users-table',
  templateUrl: 'admin-project-project-users-table.component.html',
})
export class AdminProjectProjectUsersTableComponent {
  @Input() public projectUsers: ProjectUserUser[];
  @Output() public showEdit: EventEmitter<ProjectUserUser> = new EventEmitter();
  @Output() public showConfirmRemove: EventEmitter<ProjectUserUser> = new EventEmitter();
  public displayedColumns = ['image', 'name', 'role', 'options'];

  public doShowConfirmRemove(user: ProjectUserUser) {
    this.showConfirmRemove.emit(user);
  }

  public getFullName(projectUser: ProjectUserUser) {
    return `${projectUser.user.firstName} ${projectUser.user.lastName}`;
  }
}
