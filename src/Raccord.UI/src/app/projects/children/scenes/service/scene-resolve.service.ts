import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SceneHttpService } from './scene-http.service';
import { FullScene } from '../model/full-scene.model';
@Injectable()
export class SceneResolve implements Resolve<FullScene> {

  constructor(
      private sceneHttpService: SceneHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot){
    let sceneId = route.params['sceneId'];

    return this.sceneHttpService.get(sceneId).then(scene => {
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