import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ShootingDayHttpService } from './shooting-day-http.service';
import { ShootingDaySummary } from "../model/shooting-day-summary.model";
@Injectable()
export class CompletedShootingDaysResolve implements Resolve<ShootingDaySummary[]> {

  constructor(
    private shootingDayHttpService: ShootingDayHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this.shootingDayHttpService.getCompleted(projectId).then(data => {
            return data;
        });
    }
}