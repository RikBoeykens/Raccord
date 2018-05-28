import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminUserInvitationHttpService } from './admin-user-invitation-http.service';
import { UserInvitationSummary } from '../../../invitations/model/user-invitation-summary.model';

@Injectable()
export class AdminUserInvitationsResolve implements Resolve<UserInvitationSummary[]> {

  constructor(
    private _userInvitationHttpService: AdminUserInvitationHttpService,
    private router: Router
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        return this._userInvitationHttpService.getAll().then((data) => {
            return data;
        });
    }
}