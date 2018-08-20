import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import {
  AdminFullProjectUserInvitation,
  AdminProjectUserInvitationHttpService
} from '../../..';

@Injectable()
export class AdminProjectUserInvitationResolve implements Resolve<AdminFullProjectUserInvitation> {

  constructor(
      private _projectUserInvitationHttpService: AdminProjectUserInvitationHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const id = route.params['projectUserInvitationId'];

    return this._projectUserInvitationHttpService.get(id)
      .then((data: AdminFullProjectUserInvitation) => data);
  }
}
