import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CallsheetHttpService } from './callsheet-http.service';
import { CallsheetSummary } from '../model/callsheet-summary.model';

@Injectable()
export class CallsheetSummaryResolve implements Resolve<CallsheetSummary> {

    constructor(
        private _callsheetHttpService: CallsheetHttpService
    ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const id = route.params['callsheetId'];

        return this._callsheetHttpService.getSummary(id).then((data: CallsheetSummary) => data);
    }
}
