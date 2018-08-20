import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { FullScriptLocation } from '../model/full-script-location.model';
import { ScriptLocationHttpService } from './script-location-http.service';

@Injectable()
export class ScriptLocationResolve implements Resolve<FullScriptLocation> {

    constructor(
        private _scriptLocationHttpService: ScriptLocationHttpService
    ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const id = route.params['scriptLocationId'];

        return this._scriptLocationHttpService.get(id).then((data: FullScriptLocation) => data);
    }
}
