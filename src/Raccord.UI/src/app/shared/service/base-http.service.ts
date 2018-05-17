import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { JsonResponse } from '../model/json-response.model';
import { SortOrder } from '../model/sort-order.model';
import { HeaderHelpers } from '../helpers/header.helpers';
import 'rxjs/add/operator/toPromise';
import { AuthService } from '../../security/service/auth.service';

@Injectable()
export abstract class BaseHttpService {

    protected _baseUri: string;

    constructor(
        protected _http: Http,
        private authHttpService: AuthService
    ) {
    }

    protected doGetArray(uri: string, useAuthToken: Boolean = true) {
        let headers = useAuthToken ? this.getAuthJsonHeaders() : HeaderHelpers.JsonHeaders();
        return this._http.get(uri, {headers})
            .toPromise()
            .then((response) => this.extractArray(response))
            .catch(this.handleErrorPromise);
    }

    protected doGet(uri: string, useAuthToken: Boolean = true) {
        let headers = useAuthToken ? this.getAuthJsonHeaders() : HeaderHelpers.JsonHeaders();
        return this._http.get(uri, {headers})
            .toPromise()
            .then((response) => response.json())
            .catch(this.handleErrorPromise);
    }

    protected doPost(object: any, uri: string, useAuthToken: Boolean = true) {

        let body = JSON.stringify(object);
        let headers = useAuthToken ?
                        this.getAuthFormHeaders() :
                        HeaderHelpers.ContentHeaders();
        return this._http.post(uri, body, {headers})
            .toPromise()
            .then((response) => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected doDelete(uri: string, useAuthToken: Boolean = true) {
        let headers = useAuthToken ?
                        this.getAuthFormHeaders() :
                        HeaderHelpers.ContentHeaders();

        return this._http.delete(uri, {headers})
            .toPromise()
            .then((response) => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected doSort(order: SortOrder, uri: string, useAuthToken: Boolean = true) {
        let body = JSON.stringify(order);
        let headers = useAuthToken ?
                        this.getAuthFormHeaders() :
                        HeaderHelpers.ContentHeaders();

        return this._http.post(uri, body, { headers })
            .toPromise()
            .then((response) => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected doFilePost(files: File[], object: any, uri: string, useAuthToken: Boolean = true) {
        let formData = new FormData();
        for (let file of files) {
            formData.append('files', file, file.name);
        }
        for (let property in object) {
            if (Object.prototype.hasOwnProperty.call(object, property)) {
                formData.append(property, object[property]);
            }
        }

        let headers = useAuthToken ?
                        this.getAuthFormDataHeaders() :
                        HeaderHelpers.FormDataHeaders();

        return this._http.post(uri, formData, { headers })
            .toPromise()
            .then((response) => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected extractJsonResponse(res: Object) {

        let response = <JsonResponse> res;

        if (!response.ok) {
            return response.message;
        }

        return response.data;
    }

    protected extractArray(res: Object, showprogress: boolean = true) {
        let data = res;
        return data || [];
    }

    protected handleErrorPromise(error: any): Promise<void> {
        let errMsg = '';
        try {
            error = JSON.parse(error._body);
        } finally {
            errMsg = error.errorMessage
            ? error.errorMessage
            : error.message
                ? error.message
                : error._body
                    ? error._body
                    : error.status
                        ? `${error.status} - ${error.statusText}`
                        : 'unknown server error';
        }
        console.error(errMsg);
        return Promise.reject(errMsg);
    }

    private getAuthJsonHeaders(): Headers {
        let headers = HeaderHelpers.AuthJsonHeaders();
        headers.append('Authorization', `Bearer ${this.authHttpService.getAccessToken()}`);
        return headers;
    }

    private getAuthFormHeaders(): Headers {
        let headers = HeaderHelpers.AuthFormHeaders();
        headers.append('Authorization', `Bearer ${this.authHttpService.getAccessToken()}`);
        return headers;
    }

    private getAuthFormDataHeaders(): Headers {
        let headers = HeaderHelpers.AuthFormDataHeaders();
        headers.append('Authorization', `Bearer ${this.authHttpService.getAccessToken()}`);
        return headers;
    }
}
