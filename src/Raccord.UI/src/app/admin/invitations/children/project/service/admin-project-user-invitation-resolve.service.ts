import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminProjectUserInvitationHttpService }
    from './admin-project-user-invitation-http.service';
import { FullProjectUserInvitation } from '../model/full-project-user-invitation.model';

@Injectable()
export class AdminProjectUserInvitationResolve implements Resolve<FullProjectUserInvitation> {

  constructor(
    private _projectUserInvitationHttpService: AdminProjectUserInvitationHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectUserInvitationId = route.params['projectUserInvitationId'];
        return this._projectUserInvitationHttpService.get(projectUserInvitationId).then(data => {
            return data;
        });
    }
}