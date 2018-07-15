import { Component, Input, Output, EventEmitter } from '@angular/core';
import {
  ProjectUserInvitationProject
} from '../../../../../../../shared/children/user-invitations';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  selector: 'admin-user-invitation-project-user-invitations-table',
  templateUrl: 'admin-user-invitation-project-user-invitations-table.component.html',
})
export class AdminUserInvitationProjectUserInvitationsTableComponent {
  @Input() public projectUserInvitations: ProjectUserInvitationProject[];
  @Output() public showEdit: EventEmitter<ProjectUserInvitationProject> = new EventEmitter();
  @Output() public showConfirmRemove:
    EventEmitter<ProjectUserInvitationProject> = new EventEmitter();
  public displayedColumns = ['image', 'title', 'role', 'options'];

  public doShowConfirmRemove(projectUserInvitation: ProjectUserInvitationProject) {
    this.showConfirmRemove.emit(projectUserInvitation);
  }

  public getAdminProjectUserInvitationLink(projectUserInvitation: ProjectUserInvitationProject) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.ADMIN}/${RouteSettings.PROJECTUSERINVITATIONS}/${projectUserInvitation.id}`;
  }
}
