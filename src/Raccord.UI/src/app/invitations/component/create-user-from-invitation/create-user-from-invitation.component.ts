import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CreateUserFromInvitation } from '../..';
import { InvitationHttpService } from '../../service/invitation-http.service';
import { LoadingWrapperService, ValidationHelpers, RouteSettings } from '../../../shared';
import { AuthService, LoginService } from '../../../security';
import { UserInvitationSummary } from '../../../shared/children/user-invitations';

@Component({
    templateUrl: 'create-user-from-invitation.component.html'
})
export class CreateUserFromInvitationComponent implements OnInit {
    public request: CreateUserFromInvitation = new CreateUserFromInvitation();
    public confirmPassword: string;
    private emailAddress: string;

    constructor(
        private _invitationHttpService: InvitationHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _authService: AuthService,
        private _loginService: LoginService,
        private _router: Router,
        private _route: ActivatedRoute
    ) {
    }

    public ngOnInit() {
        this._authService.logout();
        this._route.data.subscribe((data: {
            invitation: UserInvitationSummary
        }) => {
            if (data.invitation.acceptedDate) {
                this._router.navigate([RouteSettings.LOGIN]);
            } else {
                this.request = new CreateUserFromInvitation({
                    id: data.invitation.id,
                    firstName: data.invitation.firstName,
                    lastName: data.invitation.lastName,
                    password: ''
                });
                this.emailAddress = data.invitation.email;
            }
        });
    }
    public createUser() {
        this._loadingWrapperService.Load(
            this._invitationHttpService.createUser(this.request),
            () => this.login()
        );
    }

    public passwordIsValid(): boolean {
        return ValidationHelpers.isValidPassword(this.request.password);
    }

    public passwordsdMatch(): boolean {
        return this.request.password === this.confirmPassword;
    }

    private login() {
        this._loginService.login({
            username: this.emailAddress,
            password: this.request.password
        }).then(() => this._router.navigate(['/']));
    }
}
