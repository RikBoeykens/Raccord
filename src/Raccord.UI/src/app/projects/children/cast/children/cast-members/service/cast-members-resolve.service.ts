import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CastMemberSummary } from '../../../../../../shared/children/cast';
import { CastMemberHttpService } from './cast-member-http.service';

@Injectable()
export class CastMembersResolve implements Resolve<CastMemberSummary[]> {

  constructor(
    private castMemberHttpService: CastMemberHttpService
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const projectId = route.params['projectId'];
        return this.castMemberHttpService.getAll(projectId)
            .then((data: CastMemberSummary[]) => data);
    }
}
