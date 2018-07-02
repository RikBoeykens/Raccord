import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ProjectUserInvitationUserInvitation } from '../../../../../shared/children/users';

@Component({
  selector: 'admin-project-project-invitations-table',
  templateUrl: 'admin-project-project-invitations-table.component.html',
})
export class AdminProjectProjectInvitationsTableComponent {
  @Input() public projectUserInvitations: ProjectUserInvitationUserInvitation[];
  @Output() public showEdit: EventEmitter<ProjectUserInvitationUserInvitation> = new EventEmitter();
  @Output() public showConfirmRemove:
    EventEmitter<ProjectUserInvitationUserInvitation> = new EventEmitter();
  public displayedColumns = ['image', 'name', 'role', 'options'];

  public doShowConfirmRemove(invitation: ProjectUserInvitationUserInvitation) {
    this.showConfirmRemove.emit(invitation);
  }

  public getFullName(projectInvitation: ProjectUserInvitationUserInvitation) {
    // tslint:disable-next-line:max-line-length
    return `${projectInvitation.userInvitation.firstName} ${projectInvitation.userInvitation.lastName}`;
  }
}
