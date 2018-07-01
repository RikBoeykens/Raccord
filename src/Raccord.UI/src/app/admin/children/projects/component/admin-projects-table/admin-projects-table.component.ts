import { Component, Input, Output, EventEmitter } from '@angular/core';
import { AdminProjectSummary } from '../../../..';
import { Project } from '../../../../../shared/children/projects';

@Component({
  selector: 'admin-projects-table',
  templateUrl: 'admin-projects-table.component.html',
})
export class AdminProjectsTableComponent {
  @Input() public projects: AdminProjectSummary[];
  @Output() public showEditProject: EventEmitter<Project> = new EventEmitter();
  @Output() public showConfirmRemove: EventEmitter<Project> = new EventEmitter();
  public displayedColumns = ['image', 'title', 'usercount', 'invitationcount', 'options'];

  public doShowEditProject(project: Project) {
    this.showEditProject.emit(project);
  }
  public doShowConfirmRemove(project: Project) {
    this.showConfirmRemove.emit(project);
  }
}
