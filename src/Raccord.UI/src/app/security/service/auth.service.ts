import { Component } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { Http, Headers } from '@angular/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { OpenIdDictToken } from '../';
import { Login } from '../';
import { TokenHelpers } from '../helpers/token.helpers';
import { HeaderHelpers } from '../../shared/helpers/header.helpers';
import { AccountHelpers } from '../../account/helpers/account.helper';
import { Observable } from 'rxjs/Observable';
import { SaveToken } from '../model/save-token';
import 'rxjs/add/observable/fromPromise';

@Injectable()
export class AuthService {
    private _baseUri: string;

    constructor(private _http: Http) {
        this._baseUri = `${AppSettings.API_ENDPOINT}/authorization`;
    }

    public login(login: Login): Promise<any> {
        return this.retrieveTokens(login, 'password');
    }

    // called when logging out user; clears tokens from browser
    public logout() {
        TokenHelpers.removeTokens();
        AccountHelpers.removeUser();
    }

    // simple check of logged in status: if there is a token, we're (probably) logged in.
    // ideally we check status and check token has not expired
    // (server will back us up, if this not done, but it could be cleaner)
    public loggedIn() {
        return !!TokenHelpers.getTokens();
    }

    public getAccessToken(): Observable<string> {
        let tokens = TokenHelpers.getTokens();
        if (!tokens) {
            return Observable.of(null);
        }
        if (new Date().getTime() >= tokens.expiryDate) {
            return Observable.fromPromise(this.refreshToken(tokens))
                .catch(() => Observable.throw(this.logout()));
        }
        return Observable.of(tokens.accessToken);
    }

    private refreshToken(tokens: SaveToken): Promise<string> {
        console.info('doing refresh token call');
        return this.retrieveTokens({refresh_token: tokens.refreshToken}, 'refresh_token');
    }

    private retrieveTokens(data: any, grantType: string): Promise<string> {
        let uri = `${this._baseUri}/connect/token`;

        Object.assign(data, { grant_type: grantType, scope: 'openid offline_access' });

        const params = new URLSearchParams();
        Object.keys(data)
            .forEach((key) => params.append(key, data[key]));

        return this._http.post(uri, params.toString(), { headers: HeaderHelpers.ContentHeaders() })
                    .toPromise()
                    .then((response) => {
                        let token = <OpenIdDictToken> response.json();
                        this.internalLogin(token);
                        return token.access_token;
                    });
    }

    // After a successful login, save token data into session storage
    private internalLogin(responseData: OpenIdDictToken) {
        TokenHelpers.setTokens(responseData);
    }
}
