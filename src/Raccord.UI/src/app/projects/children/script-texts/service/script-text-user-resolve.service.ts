import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SceneText } from '../model/scene-text.model';
import { ScriptTextHttpService } from './script-text-http.service';
@Injectable()
export class ScriptTextUserResolve implements Resolve<SceneText[]> {

  constructor(
    private scriptTextHttpService: ScriptTextHttpService,
    private router: Router
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this.scriptTextHttpService.getForUser(projectId).then((data) => {
            return data;
        });
    }
}