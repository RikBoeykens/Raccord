import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SceneService } from './scene.service';
import { Scene } from '../model/scene.model';
@Injectable()
export class SceneResolve implements Resolve<Scene> {

  constructor(
      private sceneService: SceneService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot): Promise<Scene>|boolean {
    let sceneId = route.params['sceneId'];

    return this.sceneService.get(sceneId).then(scene => {
        if (scene) {
            return scene;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}