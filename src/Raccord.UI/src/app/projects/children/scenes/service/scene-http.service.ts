import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { SceneSummary } from '../model/scene-summary.model';
import { Scene } from '../model/scene.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';

@Injectable()
export class SceneHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/scenes`;
    }

    getAll(projectId): Promise<SceneSummary[]> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<Scene>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<SceneSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(scene: SceneSummary): Promise<Number> {
        var uri = this._baseUri;

        return this.doPost(scene, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
