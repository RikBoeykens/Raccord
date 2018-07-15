import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminUserInvitationHttpService } from './admin-user-invitation-http.service';
import { AdminUserInvitationSummary } from '../../..';

@Injectable()
export class AdminUserInvitationsResolve implements Resolve<AdminUserInvitationSummary[]> {

  constructor(
      private _userInvitationHttpService: AdminUserInvitationHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    return this._userInvitationHttpService.getAll()
      .then((data: AdminUserInvitationSummary[]) => data);
  }
}
