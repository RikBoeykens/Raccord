import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CastMemberHttpService } from './cast-member-http.service';
import { FullCastMember } from '../model/full-cast-member.model';

@Injectable()
export class CastMemberResolve implements Resolve<FullCastMember> {

  constructor(
      private castMemberHttpService: CastMemberHttpService,
      private router: Router
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    let castMemberId = route.params['castMemberId'];

    return this.castMemberHttpService.get(castMemberId).then((castMember: FullCastMember) => {
        if (castMember) {
            return castMember;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}