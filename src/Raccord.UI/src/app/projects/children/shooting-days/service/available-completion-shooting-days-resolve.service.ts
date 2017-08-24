import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ShootingDayHttpService } from './shooting-day-http.service';
import { ShootingDay } from '../model/shooting-day.model';
@Injectable()
export class AvailableCompletionShootingDaysResolve implements Resolve<ShootingDay[]> {

  constructor(
    private shootingDayHttpService: ShootingDayHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this.shootingDayHttpService.getAvailableForCompletion(projectId).then(data => {
            return data;
        });
    }
}