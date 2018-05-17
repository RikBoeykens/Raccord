import { Component } from '@angular/core';
import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { OpenIdDictToken } from '../';
import { Login } from '../';
import { TokenHelpers } from '../helpers/token.helpers';
import { HeaderHelpers } from '../../shared/helpers/header.helpers';
import { AccountHelpers } from '../../account/helpers/account.helper';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AuthService {
    private _baseUri: string;

    constructor(private _http: HttpClient) {
        this._baseUri = `${AppSettings.API_ENDPOINT}/authorization`;
    }

    public login(login: Login): Promise<any> {
        let uri = `${this._baseUri}/connect/token`;

        let body = 'username=' +
                    login.email +
                    '&password=' +
                    login.password +
                    '&grant_type=password';

        return this._http.post(uri, body, { headers: HeaderHelpers.ContentHeaders() })
                    .toPromise()
                    .then((response: OpenIdDictToken) => {
                        this.internalLogin(response);
                    });
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

    public getAccessToken(): string {
        let tokens = TokenHelpers.getTokens();
        if (new Date() > tokens.expiryDate) {
            this.logout();
        }
        return tokens.accessToken;
    }

    // After a successful login, save token data into session storage
    private internalLogin(responseData: OpenIdDictToken) {
        TokenHelpers.setTokens(responseData);
    }
}
