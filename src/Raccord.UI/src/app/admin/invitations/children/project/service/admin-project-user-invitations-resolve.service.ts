import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminProjectUserInvitationHttpService } from
    './admin-project-user-invitation-http.service';
import { ProjectUserInvitationSummary } from '../model/project-user-invitation-summary.model';

@Injectable()
export class AdminProjectUserInvitationsResolve implements Resolve<ProjectUserInvitationSummary[]> {

  constructor(
    private _projectUserInvitationHttpService: AdminProjectUserInvitationHttpService,
    private router: Router
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        let invitationId = route.params['invitationId'];
        return this._projectUserInvitationHttpService.getAll(invitationId).then((data) => {
            return data;
        });
    }
}