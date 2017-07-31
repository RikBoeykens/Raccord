import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CallsheetCharacterHttpService } from './callsheet-character-http.service';
import { CallsheetCharacterCharacter } from '../../../';
@Injectable()
export class CallsheetCharactersCharactersResolve implements Resolve<CallsheetCharacterCharacter[]> {

  constructor(
    private _callsheetCharacterHttpService: CallsheetCharacterHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let callsheetId = route.params['callsheetId'];
        return this._callsheetCharacterHttpService.getCharacters(callsheetId).then(data => {
            return data;
        });
    }
}