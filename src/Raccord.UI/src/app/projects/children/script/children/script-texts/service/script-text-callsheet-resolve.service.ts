import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SceneText } from '../../../../..';
import { ScriptTextHttpService } from './script-text-http.service';

@Injectable()
export class ScriptTextCallsheetResolve implements Resolve<SceneText[]> {

  constructor(
    private scriptTextHttpService: ScriptTextHttpService
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const id = route.params['callsheetId'];
        return this.scriptTextHttpService.getForCallsheet(id).then((data: SceneText[]) => data);
    }
}
