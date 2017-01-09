import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { DayNightHttpService } from './day-night-http.service';
import { DayNight } from '../model/day-night.model';
@Injectable()
export class DayNightResolve implements Resolve<DayNight> {

  constructor(
      private dayNightHttpService: DayNightHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot): Promise<DayNight>|boolean {
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