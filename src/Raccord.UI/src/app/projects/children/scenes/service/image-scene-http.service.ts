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
import { AuthService } from '../../../../security/service/auth.service';

@Injectable()
export class ImageSceneHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ENDPOINT}/imagescenes`;
    }

    getImages(sceneId): Promise<LinkedImage[]> {

        var uri = `${this._baseUri}/${sceneId}/images`;

        return this.doGetArray(uri);
    }

    addLink(imageId: number, sceneId: number): Promise<any>{
        var uri = `${this._baseUri}/${imageId}/${sceneId}/addlink`;

        return this.doPost(null, uri);
    }

    removeLink(linkID: number): Promise<any>{
        var uri = `${this._baseUri}/${linkID}/removelink`;

        return this.doPost(null, uri);
    }

    setImageAsPrimary(linkID: number): Promise<any>{
        var uri = `${this._baseUri}/${linkID}/setprimary`;

        return this.doPost(null, uri);
    }

    removeImageAsPrimary(linkID: number): Promise<any>{
        var uri = `${this._baseUri}/${linkID}/removeprimary`;

        return this.doPost(null, uri);
    }
}
