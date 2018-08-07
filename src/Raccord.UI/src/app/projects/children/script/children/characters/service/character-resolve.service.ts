import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { FullCharacter } from '../model/full-character.model';
import { CharacterHttpService } from './character-http.service';

@Injectable()
export class CharacterResolve implements Resolve<FullCharacter> {

    constructor(
        private _characterHttpService: CharacterHttpService
    ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const id = route.params['characterId'];

        return this._characterHttpService.get(id).then((data: FullCharacter) => data);
    }
}
