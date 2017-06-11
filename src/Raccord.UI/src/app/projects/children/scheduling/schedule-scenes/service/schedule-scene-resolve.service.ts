import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ScheduleSceneHttpService } from './schedule-scene-http.service';
import { FullScheduleScene } from '../model/full-schedule-scene.model';
@Injectable()
export class ScheduleSceneResolve implements Resolve<FullScheduleScene> {

  constructor(
      private scheduleSceneHttpService: ScheduleSceneHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let scheduleSceneId = route.params['scheduleSceneId'];

    return this.scheduleSceneHttpService.get(scheduleSceneId).then(scheduleScene => {
        if (scheduleScene) {
            return scheduleScene;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}