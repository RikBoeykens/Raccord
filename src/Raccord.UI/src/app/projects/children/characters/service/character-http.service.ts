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

    public getAll(projectId): Promise<CharacterSummary[]> {

        let uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    public getAllForCastMember(castMemberId): Promise<CharacterSummary[]> {

        let uri = `${this._baseUri}/${castMemberId}/castmember`;

        return this.doGetArray(uri);
    }

    public get(id: number): Promise<FullCharacter>{

        let uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(id: Number): Promise<CharacterSummary> {

        let uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    public post(character: Character): Promise<number> {
        let uri = this._baseUri;

        return this.doPost(character, uri);
    }

    public delete(id: Number): Promise<any> {
        let uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }

    public merge(toId: Number, mergeId): Promise<any> {
        let uri = `${this._baseUri}/merge/${toId}/${mergeId}`;

        return this.doPost(null, uri);
    }
}
