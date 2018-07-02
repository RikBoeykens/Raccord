import { AdminFullProject } from '../../model/admin-full-project.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Project } from '../../../../../shared/children/projects';
import { MatDialog } from '@angular/material';
import { AdminEditProjectDialogComponent } from '../../../..';
import { AdminProjectHttpService } from '../../service/admin-project-http.service';
import { LoadingWrapperService } from '../../../../../shared';

@Component({
  templateUrl: 'admin-project-dashboard.component.html',
})
export class AdminProjectDashboardComponent implements OnInit {
  public project: AdminFullProject;

  constructor(
    private _adminProjectHttpService: AdminProjectHttpService,
    private _loadingWrapperService: LoadingWrapperService,
    private _route: ActivatedRoute,
    private _dialog: MatDialog
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { project: AdminFullProject }) => {
      this.project = data.project;
    });
  }

  public showEditProject() {
    const editProjectDialog = this._dialog.open(AdminEditProjectDialogComponent, {data:
    {
        project: new Project(this.project),
        dialogTitle: 'Edit Project'
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
        this.project.title = project.title;
      }
    );
  }
}
