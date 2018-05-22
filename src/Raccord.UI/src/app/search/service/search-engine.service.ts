import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { SearchRequest } from '../model/search-request.model';
import { SearchTypeResult } from '../model/search-type-result.model';
import { JsonResponse } from '../../shared/model/json-response.model';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class SearchEngineService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/searchengine`;
    }

    public search(request: SearchRequest): Promise<SearchTypeResult[]> {
        let uri = this._baseUri;

        return this.doPost(request, uri);
    }
}
