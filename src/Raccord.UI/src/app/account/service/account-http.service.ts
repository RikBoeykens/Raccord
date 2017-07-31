import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { UserSummary } from '../model/user-summary.model';
import { JsonResponse } from '../../shared/model/json-response.model';

@Injectable()
export class AccountHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/account`;
    }

    getSummary(): Promise<UserSummary> {

        var uri = `${this._baseUri}/summary`;

        return this.doGet(uri);
    }
}
