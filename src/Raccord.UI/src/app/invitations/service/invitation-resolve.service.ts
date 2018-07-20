import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { InvitationHttpService } from './invitation-http.service';
import { UserInvitationSummary } from '../../shared/children/user-invitations';

@Injectable()
export class InvitationResolve implements Resolve<UserInvitationSummary> {

  constructor(
      private _invitationHttpService: InvitationHttpService,
      private router: Router
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const invitationId = route.params['invitationId'];
    return this._invitationHttpService.get(invitationId).then((data) => {
        if (data) {
            return data;
        }
    });
  }
}
