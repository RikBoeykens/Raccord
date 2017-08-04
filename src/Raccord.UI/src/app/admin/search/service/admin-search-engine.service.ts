import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { AppSettings } from '../../../app.settings';
import { SearchRequest } from "../../../search/model/search-request.model";
import { SearchTypeResult } from "../../../search/model/search-type-result.model";

@Injectable()
export class AdminSearchEngineService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/searchengine`;
    }

    search(request: SearchRequest): Promise<SearchTypeResult[]> {
        var uri = this._baseUri;

        return this.doPost(request, uri);
    }
}