import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { AppSettings } from '../../../app.settings';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { AuthService } from '../../../security/service/auth.service';

@Injectable()
export class AdminProjectUserCastHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/projectusercast`;
    }

    public addLink(projectUserId: number, castMemberId: number): Promise<any> {
        let uri = `${this._baseUri}/${projectUserId}/${castMemberId}/addlink`;

        return this.doPost(null, uri);
    }

    public removeLink(projectUserId: number, castMemberId: number): Promise<any> {
        let uri = `${this._baseUri}/${projectUserId}/${castMemberId}/removelink`;

        return this.doPost(null, uri);
    }
}
