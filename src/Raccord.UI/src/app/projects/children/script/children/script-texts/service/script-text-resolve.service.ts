import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SceneText } from '../../../../..';
import { ScriptTextHttpService } from './script-text-http.service';

@Injectable()
export class ScriptTextResolve implements Resolve<SceneText[]> {

  constructor(
    private scriptTextHttpService: ScriptTextHttpService
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const id = route.params['projectId'];
        return this.scriptTextHttpService.getForProject(id).then((data: SceneText[]) => data);
    }
}
