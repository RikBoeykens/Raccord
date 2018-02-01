import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullScene } from '../../model/full-scene.model';
import { SceneSummary } from '../model/scene-summary.model';
import { Scene } from '../model/scene.model';
import { LinkedCharacter } from '../../../characters/model/linked-character.model';
import { LinkedScheduleScene } from '../../schedule-scenes/model/linked-schedule-scene.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { SortOrder } from '../../../../shared/model/sort-order.model';
import { BaseProjectHttpService } from '../../../../shared/service/base-project-http.service';

@Injectable()
export class ScheduleCharacterHttpService extends BaseProjectHttpService {

    constructor(protected _http: Http) {
        super(_http, 'schedulecharacters');
    }

    public getCharacters(authProjectId: number, sceneId): Promise<LinkedCharacter[]> {

        let uri = `${this.getUri(authProjectId)}/${sceneId}/characters`;

        return this.doGetArray(uri);
    }

    public getScenes(authProjectId: number, characterId): Promise<LinkedScheduleScene[]> {

        let uri = `${this.getUri(authProjectId)}/${characterId}/schedulescenes`;

        return this.doGetArray(uri);
    }

    public addLink(
        authProjectId: number,
        scheduleSceneId: number,
        characterSceneId: number
    ): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/${scheduleSceneId}/${characterSceneId}/addlink`;

        return this.doPost(null, uri);
    }

    public removeLink(authProjectId: number, linkID: number): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/${linkID}/removelink`;

        return this.doPost(null, uri);
    }
}
