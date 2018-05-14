import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { FullScene } from '../model/full-scene.model';
import { SceneSummary } from '../model/scene-summary.model';
import { Scene } from '../model/scene.model';
import { SceneBreakdownItem } from
    '../../breakdowns/children/breakdown-items/model/scene-breakdown-item.model';
import { LinkedScene } from '..//model/linked-scene.model';

@Injectable()
export class BreakdownItemSceneHttpService extends BaseHttpService {

    constructor(protected _http: Http) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/breakdownitemscenes`;
    }

    public getBreakdownItems(sceneId: number, breakdownId: number): Promise<SceneBreakdownItem[]> {

        let uri = `${this._baseUri}/${sceneId}/items/${breakdownId}`;

        return this.doGetArray(uri);
    }

    public getScenes(itemId): Promise<LinkedScene[]> {

        let uri = `${this._baseUri}/${itemId}/scenes`;

        return this.doGetArray(uri);
    }

    public addLink(breakdownItemId: number, sceneId: number): Promise<any> {
        let uri = `${this._baseUri}/${breakdownItemId}/${sceneId}/addlink`;

        return this.doPost(null, uri);
    }

    public removeLink(linkID: number): Promise<any> {
        let uri = `${this._baseUri}/${linkID}/removelink`;

        return this.doPost(null, uri);
    }
}
