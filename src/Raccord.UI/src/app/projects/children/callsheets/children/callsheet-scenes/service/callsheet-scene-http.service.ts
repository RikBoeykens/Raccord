import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import { FullCallsheetScene } from '../model/full-callsheet-scene.model';
import { CallsheetSceneCallsheet } from '../model/callsheet-scene-callsheet.model';
import { CallsheetSceneScene } from '../model/callsheet-scene-scene.model';
import { CallsheetScene } from '../model/callsheet-scene.model';
import { JsonResponse } from '../../../../../shared/model/json-response.model';

@Injectable()
export class CallsheetSceneHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/callsheetscenes`;
    }

    getScenes(id): Promise<CallsheetSceneScene[]> {

        var uri = `${this._baseUri}/${id}/callsheet`;

        return this.doGetArray(uri);
    }

    getDays(id): Promise<CallsheetSceneCallsheet[]> {

        var uri = `${this._baseUri}/${id}/scene`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullCallsheetScene>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    post(callsheetScene: CallsheetScene): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(callsheetScene, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}