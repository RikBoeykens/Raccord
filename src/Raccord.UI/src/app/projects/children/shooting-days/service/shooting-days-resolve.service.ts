import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ShootingDayHttpService } from './shooting-day-http.service';
import { ShootingDay } from '../model/shooting-day.model';
@Injectable()
export class ShootingDaysResolve implements Resolve<ShootingDay[]> {

  constructor(
    private shootingDayHttpService: ShootingDayHttpService,
    private router: Router
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        let crewUnitId = route.params['crewUnitId'];
        return this.shootingDayHttpService.getAll(crewUnitId).then((data) => {
            return data;
        });
    }
}
