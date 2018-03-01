import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ShootingDayHttpService } from './shooting-day-http.service';
import { ShootingDayCrewUnit } from '../model/shooting-day-crew-unit.model';
@Injectable()
export class AvailableCompletionShootingDaysResolve implements Resolve<ShootingDayCrewUnit[]> {

  constructor(
    private shootingDayHttpService: ShootingDayHttpService, 
    private router: Router
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this.shootingDayHttpService.getAvailableForCompletion(projectId).then((data) => {
            return data;
        });
    }
}