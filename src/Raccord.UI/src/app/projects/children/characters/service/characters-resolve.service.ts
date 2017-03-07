import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CharacterHttpService } from './character-http.service';
import { CharacterSummary } from '../model/character-summary.model';
@Injectable()
export class CharactersResolve implements Resolve<CharacterSummary[]> {

  constructor(
    private _characterHttpService: CharacterHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this._characterHttpService.getAll(projectId).then(data => {
            return data;
        });
    }
}