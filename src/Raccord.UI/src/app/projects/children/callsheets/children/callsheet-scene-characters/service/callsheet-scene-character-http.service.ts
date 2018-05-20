import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import { FullScene } from '../../../model/full-scene.model';
import { SceneSummary } from '../model/scene-summary.model';
import { Scene } from '../model/scene.model';
import { LinkedCharacter } from '../../../../characters/model/linked-character.model';
import { LinkedCallsheetScene } from '../../../';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { SortOrder } from '../../../../shared/model/sort-order.model';

@Injectable()
export class CallsheetSceneCharacterHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/callsheetscenecharacters`;
    }

    getCharacters(callsheetSceneId): Promise<LinkedCharacter[] | void> {

        var uri = `${this._baseUri}/${callsheetSceneId}/characters`;

        return this.doGetArray(uri);
    }

    getScenes(characterId): Promise<LinkedCallsheetScene[] | void> {

        var uri = `${this._baseUri}/${characterId}/callsheetscenes`;

        return this.doGetArray(uri);
    }

    addLink(callsheetSceneId: number, characterSceneId: number): Promise<any>{
        var uri = `${this._baseUri}/${callsheetSceneId}/${characterSceneId}/addlink`;

        return this.doPost(null, uri);
    }

    removeLink(linkID: number): Promise<any>{
        var uri = `${this._baseUri}/${linkID}/removelink`;

        return this.doPost(null, uri);
    }
}
