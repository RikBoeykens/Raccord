import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FullUserInvitation } from '../../../../invitations/model/full-user-invitation.model';
import { AdminUserInvitationHttpService } from
    '../../../invitations/service/admin-user-invitation-http.service';
import { LoadingWrapperService } from '../../../../shared/service/loading-wrapper.service';
import { AdminProjectUserInvitationHttpService } from
    '../../children/project/service/admin-project-user-invitation-http.service';
import { ProjectUserInvitationSummary }
    from '../../children/project/model/project-user-invitation-summary.model';

@Component({
    templateUrl: 'admin-user-invitation-landing.component.html',
})
export class AdminUserInvitationLandingComponent implements OnInit {

    public invitation: FullUserInvitation;

    constructor(
        private _adminUserInvitationHttpService: AdminUserInvitationHttpService,
        private _adminProjectUserInvitationHttpService: AdminProjectUserInvitationHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private route: ActivatedRoute,
        private router: Router
    ) {
    }

    public ngOnInit() {
        this.route.data.subscribe((data: {
            invitation: FullUserInvitation
        }) => {
            this.invitation = data.invitation;
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
}
