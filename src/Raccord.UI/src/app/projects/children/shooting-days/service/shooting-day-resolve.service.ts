import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { FullShootingDay } from "../model/full-shooting-day.model";
import { ShootingDayHttpService } from "./shooting-day-http.service";
@Injectable()
export class ShootingDayResolve implements Resolve<FullShootingDay> {

  constructor(
      private shootingDayHttpService: ShootingDayHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let shootingDayId = route.params['shootingDayId'];

    return this.shootingDayHttpService.get(shootingDayId).then(shootingDay => {
        if (shootingDay) {
            return shootingDay;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}