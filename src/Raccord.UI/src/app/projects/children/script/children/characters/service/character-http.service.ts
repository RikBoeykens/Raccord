import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import { CharacterSummary, Character } from '../../../../../../shared/children/characters';
import { FullCharacter } from '../../../../..';

@Injectable()
export class CharacterHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/characters`;
    }

    public getAll(projectId): Promise<CharacterSummary[] | void> {

        const uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    public getAllForCastMember(castMemberId): Promise<CharacterSummary[] | void> {

        const uri = `${this._baseUri}/${castMemberId}/castmember`;

        return this.doGetArray(uri);
    }

    public get(id: number): Promise<FullCharacter | void> {

        const uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(id: number): Promise<CharacterSummary | void> {

        const uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    public post(character: Character): Promise<number> {
        const uri = this._baseUri;

        return this.doPost(character, uri);
    }

    public delete(id: number): Promise<any> {
        const uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }

    public merge(toId: number, mergeId): Promise<any> {
        const uri = `${this._baseUri}/merge/${toId}/${mergeId}`;

        return this.doPost(null, uri);
    }
}
