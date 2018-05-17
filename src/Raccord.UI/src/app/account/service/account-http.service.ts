import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { UserSummary } from '../model/user-summary.model';
import { JsonResponse } from '../../shared/model/json-response.model';
import { UserPermissionSummary } from '../model/user-permission-summary.model';
import { AuthService } from '../../security/service/auth.service';

@Injectable()
export class AccountHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ENDPOINT}/account`;
    }

    public getProjectPermissions(): Promise<UserPermissionSummary> {

        let uri = `${this._baseUri}/permissions`;

        return this.doGet(uri);
    }
}
