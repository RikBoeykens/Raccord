import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { FullShootingDay } from '../../../../..';
import { ShootingDayHttpService } from './shooting-day-http.service';

@Injectable()
export class ShootingDayResolve implements Resolve<FullShootingDay> {

  constructor(
      private shootingDayHttpService: ShootingDayHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const shootingDayId = route.params['shootingDayId'];

    return this.shootingDayHttpService.get(shootingDayId).then((data: FullShootingDay) => data);
  }
}
