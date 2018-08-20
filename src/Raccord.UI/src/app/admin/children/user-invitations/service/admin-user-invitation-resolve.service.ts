import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminFullUserInvitation } from '../../..';
import { AdminUserInvitationHttpService } from './admin-user-invitation-http.service';

@Injectable()
export class AdminUserInvitationResolve implements Resolve<AdminFullUserInvitation> {

  constructor(
      private _userInvitationHttpService: AdminUserInvitationHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const id = route.params['userInvitationId'];

    return this._userInvitationHttpService.get(id).then((data: AdminFullUserInvitation) => data);
  }
}
