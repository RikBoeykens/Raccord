import { Component, OnInit } from '@angular/core';
import { ProjectSummary, Project } from '../../../../../shared/children/projects';
import { AdminProjectHttpService } from '../../service/admin-project-http.service';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { ActivatedRoute } from '@angular/router';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { MatTableDataSource, MatDialog } from '@angular/material';
// tslint:disable-next-line:max-line-length
import { AdminEditProjectDialogComponent } from '../admin-edit-project-dialog/admin-edit-project-dialog.component';
import { AdminProjectSummary } from '../../../..';

@Component({
  templateUrl: 'admin-projects-list.component.html',
})
export class AdminProjectsListComponent implements OnInit {
  public displayedColumns = ['image', 'title', 'usercount', 'invitationcount', 'options'];
  public projects: AdminProjectSummary[] = [];

  constructor(
    private _adminProjectHttpService: AdminProjectHttpService,
    private _loadingWrapperService: LoadingWrapperService,
    private _dialogService: DialogService,
    private _dialog: MatDialog,
    private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { projects: AdminProjectSummary[] }) => {
      this.setProjects(data.projects);
    });
  }

  public setProjects(projects: AdminProjectSummary[]) {
    this.projects = projects;
  }

  public getProjects() {
    this._loadingWrapperService.Load(
      this._adminProjectHttpService.getAll(),
      (data) => this.setProjects(data)
    );
  }

  public showAddProject() {
    this.showEditProjectDialog(new Project(), 'Add Project');
  }

  public showEditProject(project: Project) {
    this.showEditProjectDialog(new Project(project), 'Edit Project');
  }

  public showConfirmRemove(project: ProjectSummary) {
    this._dialogService.confirm(
      `Are you sure you want to remove ${project.title}`,
      () => this.remove(project.id)
    );
  }

  private showEditProjectDialog(project: Project, dialogTitle: string) {
    const editProjectDialog = this._dialog.open(AdminEditProjectDialogComponent, {data:
    {
        project,
        dialogTitle
    }});
    editProjectDialog.afterClosed().subscribe((returnedProject: Project) => {
      if (returnedProject) {
          this.postProject(returnedProject);
      }
    });
  }

  private postProject(project: Project) {
    this._loadingWrapperService.Load(
      this._adminProjectHttpService.post(project),
      () => {
        this.getProjects();
      }
    );
  }

  private remove(projectId: number) {
    this._loadingWrapperService.Load(
      this._adminProjectHttpService.delete(projectId),
      () => {
        this._dialogService.success('The project was successfully removed.');
        this.projects =
          this.projects.filter((project: ProjectSummary) => project.id !== projectId);
      }
    );
  }
}
