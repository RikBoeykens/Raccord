import { Injectable } from '@angular/core';
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
    const projectId = route.params['projectId'];
    const castMemberId = route.params['castMemberId'];

    return this.castMemberHttpService.get(projectId, castMemberId)
        .then((castMember: FullCastMember) => castMember);
  }
}
