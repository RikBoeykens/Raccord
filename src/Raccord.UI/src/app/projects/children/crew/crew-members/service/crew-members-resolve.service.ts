import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CrewMemberSummary } from '../model/crew-member-summary.model';
import { CrewMemberHttpService } from './crew-member-http.service';
@Injectable()
export class CrewMembersResolve implements Resolve<CrewMemberSummary[]> {

  constructor(
    private crewMemberHttpService: CrewMemberHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let crewDepartmentId = route.params['crewDepartmentId'];
        return this.crewMemberHttpService.getAll(crewDepartmentId).then(data => {
            return data;
        });
    }
}