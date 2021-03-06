import { Component, Input, Output, EventEmitter } from '@angular/core';
import { AdminProjectSummary } from '../../../..';
import { Project } from '../../../../../shared/children/projects';
import { RouteSettings } from '../../../../../shared';

@Component({
  selector: 'admin-projects-table',
  templateUrl: 'admin-projects-table.component.html',
})
export class AdminProjectsTableComponent {
  @Input() public projects: AdminProjectSummary[];
  @Output() public showEdit: EventEmitter<Project> = new EventEmitter();
  @Output() public showConfirmRemove: EventEmitter<Project> = new EventEmitter();
  public displayedColumns = ['image', 'title', 'usercount', 'invitationcount', 'options'];

  public doShowEdit(project: Project) {
    this.showEdit.emit(project);
  }
  public doShowConfirmRemove(project: Project) {
    this.showConfirmRemove.emit(project);
  }

  public getAdminProjectLink(project: Project): string {
    return `/${RouteSettings.ADMIN}/${RouteSettings.PROJECTS}/${project.id}`;
  }
}
