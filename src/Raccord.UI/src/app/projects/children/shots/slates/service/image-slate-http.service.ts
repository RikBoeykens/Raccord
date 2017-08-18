import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { LinkedImage } from '../../../images/model/linked-image.model';

@Injectable()
export class ImageSlateHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/imageslates`;
    }

    getImages(slateId): Promise<LinkedImage[]> {

        var uri = `${this._baseUri}/${slateId}/images`;

        return this.doGetArray(uri);
    }

    addLink(imageId: number, slateId: number): Promise<any>{
        var uri = `${this._baseUri}/${imageId}/${slateId}/addlink`;

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