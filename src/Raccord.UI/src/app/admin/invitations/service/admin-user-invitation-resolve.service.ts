import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminUserInvitationHttpService } from './admin-user-invitation-http.service';
import { FullUserInvitation } from '../../../invitations/model/full-user-invitation.model';

@Injectable()
export class AdminUserInvitationResolve implements Resolve<FullUserInvitation> {

  constructor(
    private _userInvitationHttpService: AdminUserInvitationHttpService,
    private router: Router
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        let invitationId = route.params['invitationId'];
        return this._userInvitationHttpService.get(invitationId).then((data) => {
            return data;
        });
    }
}
