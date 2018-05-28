import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { UserInvitationSummary } from '../model/user-invitation-summary.model';
import { InvitationHttpService } from './invitation-http.service';
@Injectable()
export class InvitationResolve implements Resolve<UserInvitationSummary> {

  constructor(
      private _invitationHttpService: InvitationHttpService,
      private router: Router
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    let invitationId = route.params['invitationId'];
    return this._invitationHttpService.get(invitationId).then((data) => {
        if (data) {
            return data;
        }
    });
  }
}
