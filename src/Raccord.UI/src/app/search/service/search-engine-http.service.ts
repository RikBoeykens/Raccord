import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { SearchRequest, SearchTypeResult } from '../../shared/children/search';

@Injectable()
export class SearchEngineHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/searchengine`;
    }

    public search(request: SearchRequest): Promise<SearchTypeResult[]> {
        const uri = this._baseUri;

        return this.doPost(request, uri);
    }
}
