import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CallsheetHttpService } from './callsheet-http.service';
import { FullCallsheet } from '../../..';

@Injectable()
export class CallsheetResolve implements Resolve<FullCallsheet> {

    constructor(
        private _callsheetHttpService: CallsheetHttpService
    ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const id = route.params['callsheetId'];

        return this._callsheetHttpService.get(id).then((data: FullCallsheet) => data);
    }
}
