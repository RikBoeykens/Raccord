import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { FullCharacter } from '../model/full-character.model';
import { CharacterSummary } from '../model/character-summary.model';
import { Character } from '../model/character.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';

@Injectable()
export class CharacterHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/characters`;
    }

    getAll(projectId): Promise<CharacterSummary[]> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullCharacter>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<CharacterSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(character: Character): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(character, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }

    merge(toId: Number, mergeId): Promise<any> {
        var uri = `${this._baseUri}/merge/${toId}/${mergeId}`;

        return this.doPost(null, uri);
    }
}
