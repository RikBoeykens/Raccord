import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SceneText } from '../model/scene-text.model';
import { ScriptTextHttpService } from './script-text-http.service';
@Injectable()
export class ScriptTextCallsheetResolve implements Resolve<SceneText[]> {

  constructor(
    private scriptTextHttpService: ScriptTextHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let callsheetId = route.params['callsheetId'];
        return this.scriptTextHttpService.getForCallsheet(callsheetId).then(data => {
            return data;
        });
    }
}