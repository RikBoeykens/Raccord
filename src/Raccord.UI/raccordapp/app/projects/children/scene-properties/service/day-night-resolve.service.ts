import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { DayNightService } from './day-night.service';
import { DayNight } from '../model/day-night.model';
@Injectable()
export class DayNightResolve implements Resolve<DayNight> {

  constructor(
      private dayNightService: DayNightService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot): Promise<DayNight>|boolean {
    let dayNightId = route.params['dayNightId'];

    return this.dayNightService.get(dayNightId).then(dayNight => {
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