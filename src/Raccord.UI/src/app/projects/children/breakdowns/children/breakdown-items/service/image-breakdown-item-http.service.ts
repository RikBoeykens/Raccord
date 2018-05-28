import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import { FullBreakdownItem } from '../model/full-breakdown-item.model';
import { BreakdownItemSummary } from '../model/breakdown-item-summary.model';
import { BreakdownItem } from '../model/breakdown-item.model';
import { LinkedImage } from '../../../../images/model/linked-image.model';

@Injectable()
export class ImageBreakdownItemHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/imagebreakdownitems`;
    }

    getImages(breakdownItemId): Promise<LinkedImage[] | void> {

        var uri = `${this._baseUri}/${breakdownItemId}/images`;

        return this.doGetArray(uri);
    }

    addLink(imageId: number, breakdownItemId: number): Promise<any>{
        var uri = `${this._baseUri}/${imageId}/${breakdownItemId}/addlink`;

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
