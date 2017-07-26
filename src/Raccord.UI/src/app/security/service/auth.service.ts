import { Component } from '@angular/core';
import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { OpenIdDictToken } from '../';
import { Login } from '../';
 
@Injectable()
export class AuthService {
    _baseUri: string;

    constructor(private _http: Http) { 
        this._baseUri = `${AppSettings.API_ENDPOINT}/authorization`;
    }

        // for requesting secure data using json
    authJsonHeaders() {
        let header = new Headers();
        header.append('Content-Type', 'application/json');
        header.append('Accept', 'application/json');
        header.append('Authorization', 'Bearer ' + sessionStorage.getItem('bearer_token'));
        return header;
    }
 
    // for requesting secure data from a form post
    authFormHeaders() {
        let header = new Headers();
        header.append('Content-Type', 'application/x-www-form-urlencoded');
        header.append('Accept', 'application/json');
        header.append('Authorization', 'Bearer ' + sessionStorage.getItem('bearer_token'));
        return header;
    }
 
    // for requesting unsecured data using json
    jsonHeaders() {
        let header = new Headers();
        header.append('Content-Type', 'application/json');
        header.append('Accept', 'application/json');
        return header;
    }
 
    // for requesting unsecured data using form post
    contentHeaders() {
        let header = new Headers();
        header.append('Content-Type', 'application/x-www-form-urlencoded');
        header.append('Accept', 'application/json');
        return header;
    }

    login(login: Login):Promise<any>{
        let uri = `${this._baseUri}/connect/token`;

        let body = 'username=' + login.email + '&password=' + login.password + '&grant_type=password';
 
        return this._http.post(uri, body, { headers: this.contentHeaders() })
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
        sessionStorage.setItem('access_token', access_token);
        sessionStorage.setItem('bearer_token', access_token);
        // TODO: implement meaningful refresh, handle expiry 
        sessionStorage.setItem('expires_in', expires_in.toString());
    }
 
    // called when logging out user; clears tokens from browser
    logout() {
        //localStorage.removeItem('access_token');
        sessionStorage.removeItem('access_token');
        sessionStorage.removeItem('bearer_token');
        sessionStorage.removeItem('expires_in');
    }
 
    // simple check of logged in status: if there is a token, we're (probably) logged in.
    // ideally we check status and check token has not expired (server will back us up, if this not done, but it could be cleaner)
    loggedIn() {
        return !!sessionStorage.getItem('bearer_token');
    }
}