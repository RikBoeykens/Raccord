import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MdDialog } from '@angular/material';
import { FullUserInvitation } from '../../../../invitations/model/full-user-invitation.model';
import { AdminUserInvitationHttpService } from
    '../../../invitations/service/admin-user-invitation-http.service';
import { LoadingWrapperService } from '../../../../shared/service/loading-wrapper.service';
import { AdminProjectUserInvitationHttpService } from
    '../../children/project/service/admin-project-user-invitation-http.service';
import { ProjectUserInvitationSummary }
    from '../../children/project/model/project-user-invitation-summary.model';
import { ProjectRole } from '../../../project-roles/model/project-role.model';
import { ProjectUserInvitation } from '../../children/project/model/project-user-invitation.model';
import { AdminChooseProjectDialogComponent } from '../../..';

@Component({
    templateUrl: 'admin-user-invitation-landing.component.html',
})
export class AdminUserInvitationLandingComponent implements OnInit {

    public invitation: FullUserInvitation;
    public projectRoles: ProjectRole[] = [];

    constructor(
        private _adminUserInvitationHttpService: AdminUserInvitationHttpService,
        private _adminProjectUserInvitationHttpService: AdminProjectUserInvitationHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _dialog: MdDialog,
        private route: ActivatedRoute,
        private router: Router
    ) {
    }

    public ngOnInit() {
        this.route.data.subscribe((data: {
            invitation: FullUserInvitation,
            projects: ProjectUserInvitationSummary[],
            projectRoles: ProjectRole[]
        }) => {
            this.invitation = data.invitation;
            this.invitation.projects = data.projects;
            this.projectRoles = data.projectRoles;
        });
    }

    public getInvitation() {
        this._loadingWrapperService.Load(
            this._adminUserInvitationHttpService.get(this.invitation.id),
            (data) => this.invitation = data
        );
    }

    public getProjects() {
        this._loadingWrapperService.Load(
            this._adminProjectUserInvitationHttpService.getAll(this.invitation.id),
            (data) => this.invitation.projects = data
        );
    }

    public getFullName(invitation: FullUserInvitation) {
        return `${invitation.firstName} ${invitation.lastName}`;
    }

    public removeProject(projectInvitation: ProjectUserInvitationSummary) {
        this._loadingWrapperService.Load(
            this._adminProjectUserInvitationHttpService.delete(projectInvitation.id),
            () => this.getProjects()
        );
    }

    public showAddProject() {
        let addProjectDialog = this._dialog.open(AdminChooseProjectDialogComponent, {data:
        {
            projectRoles: this.projectRoles
        }});
        addProjectDialog.afterClosed().subscribe((data: {
            chosenRoleId: number,
            projectId: number
        }) => {
            if (data) {
                this.addProject(data.projectId, data.chosenRoleId);
            }
        });
    }

    private addProject(projectId: number, roleId: number) {
        let projectUserInvitation = new ProjectUserInvitation();
        projectUserInvitation.userInvitationID = this.invitation.id;
        projectUserInvitation.projectID = projectId;
        projectUserInvitation.roleID = roleId;
        this._loadingWrapperService.Load(
            this._adminProjectUserInvitationHttpService.add(projectUserInvitation),
            () => this.getProjects()
        );
    }
}
