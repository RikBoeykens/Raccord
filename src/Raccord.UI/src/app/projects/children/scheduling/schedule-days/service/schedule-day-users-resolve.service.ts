import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ScheduleDayHttpService } from './schedule-day-http.service';
import { FullScheduleDayCrewUnit } from '../model/full-schedule-day-crew-unit.model';
@Injectable()
export class ScheduleDayUsersResolve implements Resolve<FullScheduleDayCrewUnit[]> {

  constructor(
    private scheduleDayHttpService: ScheduleDayHttpService,
    private router: Router
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this.scheduleDayHttpService.getAllUser(projectId).then((data) => {
            return data;
        });
    }
}
