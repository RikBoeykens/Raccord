import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SceneService } from './scene.service';
import { SceneSummary } from '../model/scene-summary.model';
@Injectable()
export class ScenesResolve implements Resolve<SceneSummary[]> {

  constructor(
    private sceneService: SceneService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot): Promise<SceneSummary[]>|boolean {
        let projectId = route.params['projectId'];
        return this.sceneService.getAll(projectId).then(data => {
            return data;
        });
    }
}