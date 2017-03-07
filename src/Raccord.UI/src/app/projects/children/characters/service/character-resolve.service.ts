import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CharacterHttpService } from './character-http.service';
import { FullCharacter } from '../model/full-character.model';
@Injectable()
export class CharacterResolve implements Resolve<FullCharacter> {

  constructor(
      private _characterHttpService: CharacterHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let characterId = route.params['characterId'];

    return this._characterHttpService.get(characterId).then(character => {
        if (character) {
            return character;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}