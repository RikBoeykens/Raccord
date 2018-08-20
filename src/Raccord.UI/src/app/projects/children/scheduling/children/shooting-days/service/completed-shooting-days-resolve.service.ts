import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ShootingDayCrewUnit } from '../../../../..';
import { ShootingDayHttpService } from './shooting-day-http.service';

@Injectable()
export class CompletedShootingDaysResolve implements Resolve<ShootingDayCrewUnit[]> {

  constructor(
    private shootingDayHttpService: ShootingDayHttpService
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const projectId = route.params['projectId'];
        return this.shootingDayHttpService.getCompleted(projectId)
            .then((data: ShootingDayCrewUnit[]) =>  data);
    }
}
