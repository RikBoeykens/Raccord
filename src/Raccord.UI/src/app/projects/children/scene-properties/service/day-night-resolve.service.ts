import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { DayNightHttpService } from './day-night-http.service';
import { FullDayNight } from '../model/full-day-night.model';
@Injectable()
export class DayNightResolve implements Resolve<FullDayNight> {

  constructor(
      private dayNightHttpService: DayNightHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let dayNightId = route.params['dayNightId'];

    return this.dayNightHttpService.get(dayNightId).then(dayNight => {
        if (dayNight) {
            return dayNight;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}