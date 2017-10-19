import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CrewMemberHttpService } from './crew-member-http.service';
import { FullCrewMember } from '../model/full-crew-member.model';

@Injectable()
export class CrewMemberResolve implements Resolve<FullCrewMember> {

  constructor(
      private takeHttpService: CrewMemberHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let crewMemberId = route.params['crewMemberId'];

    return this.takeHttpService.get(crewMemberId).then((crewMember) => {
        if (crewMember) {
            return crewMember;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}