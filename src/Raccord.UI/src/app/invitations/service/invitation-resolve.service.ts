import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { UserInvitation } from '../model/user-invitation.model';
import { InvitationHttpService } from './invitation-http.service';
@Injectable()
export class InvitationResolve implements Resolve<UserInvitation> {

  constructor(
      private _invitationHttpService: InvitationHttpService,
      private router: Router
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    let invitationId = route.params['invitationId'];
    console.log(`in resolve" ${invitationId}`);
    return this._invitationHttpService.get(invitationId).then((data) => {
        console.log(`in resolve, found data`);
        console.log(data);
        if (data) {
            return data;
        }
    });
  }
}
