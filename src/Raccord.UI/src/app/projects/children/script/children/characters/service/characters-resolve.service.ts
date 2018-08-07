import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CharacterSummary } from '../../../../../../shared/children/characters';
import { CharacterHttpService } from '../../../../..';

@Injectable()
export class CharactersResolve implements Resolve<CharacterSummary[]> {

    constructor(
        private _characterHttpService: CharacterHttpService
    ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const id = route.params['projectId'];
        return this._characterHttpService.getAll(id).then(
            (data: CharacterSummary[]) => data);
    }
}
