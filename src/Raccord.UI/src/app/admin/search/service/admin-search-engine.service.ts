import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { AppSettings } from '../../../app.settings';
import { SearchRequest } from '../../../search/model/search-request.model';
import { SearchTypeResult } from '../../../search/model/search-type-result.model';
import { AuthService } from '../../../security/service/auth.service';

@Injectable()
export class AdminSearchEngineService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/searchengine`;
    }

    public search(request: SearchRequest): Promise<SearchTypeResult[]> {
        let uri = this._baseUri;

        return this.doPost(request, uri);
    }
}
