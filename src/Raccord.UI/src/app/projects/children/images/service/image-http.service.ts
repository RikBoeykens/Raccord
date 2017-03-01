import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { FullImage } from '../model/full-image.model';
import { ImageSummary } from '../model/image-summary.model';
import { Image } from '../model/image.model';
import { LinkImage } from '../model/link-image.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';

@Injectable()
export class ImageHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/images`;
    }

    getAll(projectId): Promise<ImageSummary[]> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullImage>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<ImageSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(image: Image): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(image, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }

    upload(files: File[], projectId: number)
    {
        var uri = `${this._baseUri}/${projectId}/upload`;

        return this.doFilePost(files, null, uri);
    }

    addImageLink(link: LinkImage)
    {
        var uri = `${this._baseUri}/link`;

        return this.doPost(link, uri);
    }

    removeImageLink(link: LinkImage)
    {
        var uri = `${this._baseUri}/removelink`;

        return this.doPost(link, uri);
    }
}
