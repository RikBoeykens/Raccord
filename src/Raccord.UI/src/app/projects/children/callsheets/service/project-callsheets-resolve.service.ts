import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CallsheetHttpService } from './callsheet-http.service';
import { CallsheetCrewUnit } from '../../..';

@Injectable()
export class ProjectCallsheetsResolve implements Resolve<CallsheetCrewUnit[]> {

    constructor(
        private _callsheetHttpService: CallsheetHttpService
    ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const id = route.params['projectId'];

        return this._callsheetHttpService.getAllForProject(id)
            .then((data: CallsheetCrewUnit[]) => data);
    }
}
