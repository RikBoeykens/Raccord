import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MdDialog } from '@angular/material';
import { LinkedProjectUserUser } from '../../../project-users/model/linked-project-user-user.model';
import { ProjectSummary } from '../../../../projects';
import { FullAdminCrewUnit } from
    '../../../../projects/children/crew/crew-units/model/full-admin-crew-unit.model';
import { AdminCrewUnitMemberHttpService } from '../../service/admin-crew-unit-member-http.service';
import { LoadingWrapperService } from '../../../../shared/service/loading-wrapper.service';
import { ProjectUserUser } from '../../../project-users/model/project-user-user.model';
import { AdminProjectUserHttpService } from
    '../../../project-users/service/admin-project-user-http.service';
import { AdminChooseProjectUserDialogComponent }
    // tslint:disable-next-line:max-line-length
    from '../../../project-users/component/admin-choose-project-user-dialog/admin-choose-project-user-dialog.component';

@Component({
  templateUrl: 'admin-crew-unit-landing.component.html',
})
export class AdminCrewUnitLandingComponent implements OnInit  {

    public crewUnit: FullAdminCrewUnit;
    public project: ProjectSummary;

    constructor(
        private _crewUnitMemberHttpService: AdminCrewUnitMemberHttpService,
        private _adminProjectUserHttpService: AdminProjectUserHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private route: ActivatedRoute,
        private _dialog: MdDialog
    ) {
    }

    public ngOnInit() {
        this.route.data.subscribe((data: {
            project: ProjectSummary,
            crewUnit: FullAdminCrewUnit,
        }) => {
            this.crewUnit = data.crewUnit;
            this.project = data.project;
        });
    }

    public showAddCrewUnitMember() {
      this._loadingWrapperService.Load(
          this._adminProjectUserHttpService.getUsers(this.project.id),
          (data: ProjectUserUser[]) => {
              let availableProjectUsers = data.filter((projectUser: ProjectUserUser) =>
                this.crewUnit.projectUsers.findIndex(
                  (existingProjectUser: LinkedProjectUserUser) =>
                      existingProjectUser.id === projectUser.id) === -1);
              let projectUserDialog = this._dialog.open(
                  AdminChooseProjectUserDialogComponent, {data:
                  {
                      projectUsers: availableProjectUsers
                  }});
              projectUserDialog.afterClosed().subscribe((returnedProjectUser: ProjectUserUser) => {
                  if (returnedProjectUser) {
                      this.addUnitMemberLink(returnedProjectUser);
                  }
              });
          }
      );
    }

    public removeUnitMemberLink(projectUser: LinkedProjectUserUser) {
        this._loadingWrapperService.Load(
            this._crewUnitMemberHttpService.removeLink(projectUser.linkID),
            () => {
                this.getMembers();
            }
        );
    }

    public getFullName(projectUser: LinkedProjectUserUser) {
        return `${projectUser.user.firstName} ${projectUser.user.lastName}`;
    }

    private addUnitMemberLink(projectUser: ProjectUserUser) {
        this._loadingWrapperService.Load(
            this._crewUnitMemberHttpService.addLink(projectUser.id, this.crewUnit.id),
            () => {
                this.getMembers();
            }
        );
    }

    private getMembers() {
        this._loadingWrapperService.Load(
            this._crewUnitMemberHttpService.getProjectUsers(this.crewUnit.id),
            (data) => this.crewUnit.projectUsers = data
        );
    }
}
