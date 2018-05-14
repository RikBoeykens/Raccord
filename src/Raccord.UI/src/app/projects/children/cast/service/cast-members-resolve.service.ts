import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CastMemberSummary } from '../model/cast-member-summary.model';
import { CastMemberHttpService } from './cast-member-http.service';
@Injectable()
export class CastMembersResolve implements Resolve<CastMemberSummary[]> {

  constructor(
    private castMemberHttpService: CastMemberHttpService,
    private router: Router
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this.castMemberHttpService.getAll(projectId).then((data) => {
            return data;
        });
    }
}