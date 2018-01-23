import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { FullScene } from '../model/full-scene.model';
import { SceneSummary } from '../model/scene-summary.model';
import { Scene } from '../model/scene.model';
import { LinkedImage } from '../../images/model/linked-image.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { SortOrder } from '../../../../shared/model/sort-order.model';
import { SceneFilterRequest } from '../model/scene-filter-request.model';

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

    get(id: number): Promise<FullScene>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<SceneSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    getImages(id: number): Promise<LinkedImage[]> {

        var uri = `${this._baseUri}/${id}/images`;

        return this.doGet(uri);
    }

    post(scene: Scene): Promise<Number> {
        var uri = this._baseUri;

        return this.doPost(scene, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }

    sort(id: number, sortIds: number[]): Promise<any>{
        var uri = `${this._baseUri}/sort`;

        var sortOrder = new SortOrder({parentId: id, sortIds: sortIds});

        return this.doSort(sortOrder, uri);
    }

    filter(request: SceneFilterRequest): Promise<SceneSummary[]>{
        var uri = `${this._baseUri}/filter`;

        return this.doPost(request, uri);
    }
}
