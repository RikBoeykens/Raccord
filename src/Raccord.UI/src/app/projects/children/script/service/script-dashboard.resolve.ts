import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ScriptDashboard } from '../model/script-dashboard.model';
import { ScriptDashboardHttpService } from './script-dashboard-http.service';

@Injectable()
export class ScriptDashboardResolve implements Resolve<ScriptDashboard> {

  constructor(
    private _scriptDashboardttpService: ScriptDashboardHttpService,
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const id = route.params['projectId'];
    return this._scriptDashboardttpService.get(id).then((data: ScriptDashboard) => data);
  }
}
