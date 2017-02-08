import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SceneHttpService } from './scene-http.service';
import { SceneSummary } from '../model/scene-summary.model';
@Injectable()
export class ScenesResolve implements Resolve<SceneSummary[]> {

  constructor(
    private sceneHttpService: SceneHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this.sceneHttpService.getAll(projectId).then(data => {
            return data;
        });
    }
}