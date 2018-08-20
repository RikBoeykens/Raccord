import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ScriptLocationSummary } from '../../../../../../shared/children/script-locations';
import { ScriptLocationHttpService } from '../../../../..';

@Injectable()
export class ScriptLocationsResolve implements Resolve<ScriptLocationSummary[]> {

    constructor(
        private _scriptLocationHttpService: ScriptLocationHttpService
    ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const id = route.params['projectId'];
        return this._scriptLocationHttpService.getAll(id).then(
            (data: ScriptLocationSummary[]) => data);
    }
}
