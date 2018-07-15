import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ProjectUserProject } from '../../../../../../../shared/children/users';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  selector: 'admin-user-project-users-table',
  templateUrl: 'admin-user-project-users-table.component.html',
})
export class AdminUserProjectUsersTableComponent {
  @Input() public projectUsers: ProjectUserProject[];
  @Output() public showEdit: EventEmitter<ProjectUserProject> = new EventEmitter();
  @Output() public showConfirmRemove: EventEmitter<ProjectUserProject> = new EventEmitter();
  public displayedColumns = ['image', 'title', 'role', 'options'];

  public doShowConfirmRemove(projectUser: ProjectUserProject) {
    this.showConfirmRemove.emit(projectUser);
  }

  public getAdminProjectUserLink(projectUser: ProjectUserProject) {
    return `/${RouteSettings.ADMIN}/${RouteSettings.PROJECTUSERS}/${projectUser.id}`;
  }
}
