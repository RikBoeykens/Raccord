import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CallsheetSceneHttpService } from './callsheet-scene-http.service';
import { CallsheetSceneCharacters } from '../../../';
@Injectable()
export class CallsheetSceneCharactersResolve implements Resolve<CallsheetSceneCharacters[]> {

  constructor(
    private _callsheetSceneHttpService: CallsheetSceneHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let callsheetId = route.params['callsheetId'];
        return this._callsheetSceneHttpService.getCharacters(callsheetId).then(data => {
            return data;
        });
    }
}