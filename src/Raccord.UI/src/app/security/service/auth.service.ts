import { Component } from '@angular/core';
import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { OpenIdDictToken } from '../';
import { Login } from '../';
import { TokenHelpers } from "../";
import { HeaderHelpers } from "../../shared/helpers/header.helpers";
 
@Injectable()
export class AuthService {
    _baseUri: string;

    constructor(private _http: Http) { 
        this._baseUri = `${AppSettings.API_ENDPOINT}/authorization`;
    }

    login(login: Login):Promise<any>{
        let uri = `${this._baseUri}/connect/token`;

        let body = 'username=' + login.email + '&password=' + login.password + '&grant_type=password';
 
        return this._http.post(uri, body, { headers: HeaderHelpers.ContentHeaders() })
                    .toPromise()
                    .then((response)=>{
                        this.internalLogin(response.json());
                    });
    }
 
    // After a successful login, save token data into session storage
    // note: use "localStorage" for persistent, browser-wide logins; "sessionStorage" for per-session storage.
    internalLogin(responseData: OpenIdDictToken) {
        let access_token: string = responseData.access_token;
        let expires_in: number = responseData.expires_in;
        TokenHelpers.setTokens(access_token, expires_in);
    }
 
    // called when logging out user; clears tokens from browser
    logout() {
        TokenHelpers.removeTokens();
    }
 
    // simple check of logged in status: if there is a token, we're (probably) logged in.
    // ideally we check status and check token has not expired (server will back us up, if this not done, but it could be cleaner)
    loggedIn() {
        return !!TokenHelpers.getAcessToken();
    }
}