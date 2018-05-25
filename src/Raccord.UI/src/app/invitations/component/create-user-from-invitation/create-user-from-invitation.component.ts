import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminUserHttpService } from '../../service/admin-user-http.service';
import { UserInvitation } from '../../model/user-invitation.model';
import { InvitationHttpService } from '../../service/invitation-http.service';
import { LoadingWrapperService } from '../../../shared/service/loading-wrapper.service';
import { CreateUserFromInvitation } from '../../model/create-user-from-invitation.model';

@Component({
    templateUrl: 'create-user-from-invitation.component.html'
})
export class CreateUserFromInvitationComponent implements OnInit {
    public request: CreateUserFromInvitation = new CreateUserFromInvitation();
    public confirmpassword: string;

    constructor(
        private _invitationHttpService: InvitationHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _router: Router,
        private _route: ActivatedRoute
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            invitation: UserInvitation
        }) => {
            this.request = new CreateUserFromInvitation({
                id: data.invitation.id,
                firstName: data.invitation.firstName,
                lastName: data.invitation.lastName,
                password: ''
            });
        });
    }
    public createUser() {
        this._loadingWrapperService.Load(
            this._invitationHttpService.createUser(this.request),
            () => this._router.navigate(['login'])
        );
    }
}
