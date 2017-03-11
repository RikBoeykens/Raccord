import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { FullScene } from '../model/full-scene.model';
import { SceneSummary } from '../model/scene-summary.model';
import { Scene } from '../model/scene.model';
import { LinkedBreakdownItem } from '../../breakdowns/breakdown-items/model/linked-breakdown-item.model';
import { LinkedScene } from '..//model/linked-scene.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { SortOrder } from '../../../../shared/model/sort-order.model';

@Injectable()
export class BreakdownItemSceneHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/breakdownitemscenes`;
    }

    getBreakdownItems(sceneId): Promise<LinkedBreakdownItem[]> {

        var uri = `${this._baseUri}/${sceneId}/breakdownitems`;

        return this.doGetArray(uri);
    }

    getScenes(itemId): Promise<LinkedScene[]> {

        var uri = `${this._baseUri}/${itemId}/scenes`;

        return this.doGetArray(uri);
    }

    addLink(breakdownItemId: number, sceneId: number): Promise<any>{
        var uri = `${this._baseUri}/${breakdownItemId}/${sceneId}/addlink`;

        return this.doPost(null, uri);
    }

    removeLink(linkID: number): Promise<any>{
        var uri = `${this._baseUri}/${linkID}/removelink`;

        return this.doPost(null, uri);
    }
}
