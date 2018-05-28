import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminUserHttpService } from '../../service/admin-user-http.service';
import { UserInvitationSummary } from '../../model/user-invitation-summary.model';
import { InvitationHttpService } from '../../service/invitation-http.service';
import { LoadingWrapperService } from '../../../shared/service/loading-wrapper.service';
import { CreateUserFromInvitation } from '../../model/create-user-from-invitation.model';
import { AuthService } from '../../../security/service/auth.service';
import { Login } from '../../../security';

@Component({
    templateUrl: 'create-user-from-invitation.component.html'
})
export class CreateUserFromInvitationComponent implements OnInit {
    public request: CreateUserFromInvitation = new CreateUserFromInvitation();
    public confirmpassword: string;
    public canCreate: boolean = true;
    private emailAddress: string;

    constructor(
        private _invitationHttpService: InvitationHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _authService: AuthService,
        private _router: Router,
        private _route: ActivatedRoute
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            invitation: UserInvitationSummary
        }) => {
            this.request = new CreateUserFromInvitation({
                id: data.invitation.id,
                firstName: data.invitation.firstName,
                lastName: data.invitation.lastName,
                password: ''
            });
            if (data.invitation.acceptedDate) {
                this.canCreate = false;
            }
            this.emailAddress = data.invitation.email;
        });
    }
    public createUser() {
        this._loadingWrapperService.Load(
            this._invitationHttpService.createUser(this.request),
            () => this.login()
        );
    }

    public passwordsdMatch(): boolean {
        return this.request.password === this.confirmpassword;
    }

    private login() {
        this._authService.login({
            username: this.emailAddress,
            password: this.request.password
        }).then(() => this._router.navigate(['/']));
    }
}
