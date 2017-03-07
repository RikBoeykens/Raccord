import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { FullScene } from '../model/full-scene.model';
import { SceneSummary } from '../model/scene-summary.model';
import { Scene } from '../model/scene.model';
import { LinkedCharacter } from '../../characters/model/linked-character.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { SortOrder } from '../../../../shared/model/sort-order.model';

@Injectable()
export class CharacterSceneHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/characterscenes`;
    }

    getCharacters(sceneId): Promise<LinkedCharacter[]> {

        var uri = `${this._baseUri}/${sceneId}/characters`;

        return this.doGetArray(uri);
    }

    addLink(characterId: number, sceneId: number): Promise<any>{
        var uri = `${this._baseUri}/${characterId}/${sceneId}/addlink`;

        return this.doPost(null, uri);
    }

    removeLink(linkID: number): Promise<any>{
        var uri = `${this._baseUri}/${linkID}/removelink`;

        return this.doPost(null, uri);
    }
}
