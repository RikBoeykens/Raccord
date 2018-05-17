import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { LinkedImage } from '../../images/model/linked-image.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { SortOrder } from '../../../../shared/model/sort-order.model';
import { AuthService } from '../../../../security/service/auth.service';

@Injectable()
export class ImageCharacterHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ENDPOINT}/imagecharacters`;
    }

    getImages(characterId): Promise<LinkedImage[]> {

        var uri = `${this._baseUri}/${characterId}/images`;

        return this.doGetArray(uri);
    }

    addLink(imageId: number, characterId: number): Promise<any>{
        var uri = `${this._baseUri}/${imageId}/${characterId}/addlink`;

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
