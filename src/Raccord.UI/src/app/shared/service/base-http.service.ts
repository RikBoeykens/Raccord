import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JsonResponse } from '../model/json-response.model';
import { SortOrder } from '../model/sort-order.model';
import { HeaderHelpers } from '../helpers/header.helpers';
import 'rxjs/add/operator/toPromise';
import { ErrorInfo } from '../model/error-info.model';

@Injectable()
export abstract class BaseHttpService {

    protected _baseUri: string;

    constructor(
        protected _http: HttpClient
    ) {
    }

    protected doGetArray<T>(uri: string, useAuthToken: Boolean = true): Promise<T[] | void> {
        let headers = useAuthToken ? HeaderHelpers.AuthJsonHeaders() : HeaderHelpers.JsonHeaders();
        return this._http.get(uri, {headers})
            .toPromise()
            .then((response) => this.extractArray<T>(response))
            .catch(this.handleErrorPromise);
    }

    protected doGet<T>(uri: string, useAuthToken: Boolean = true) {
        let headers = useAuthToken ? HeaderHelpers.AuthJsonHeaders() : HeaderHelpers.JsonHeaders();
        return this._http.get(uri, {headers})
            .toPromise()
            .then((response: T) => response)
            .catch(this.handleErrorPromise);
    }

    protected doPost(object: any, uri: string, useAuthToken: Boolean = true) {
        let body = JSON.stringify(object);
        let headers = HeaderHelpers.AuthFormHeaders();
        return this._http.post(uri, body, {headers})
            .toPromise()
            .then((response) => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected doDelete(uri: string, useAuthToken: Boolean = true) {
        let headers = useAuthToken ?
                        HeaderHelpers.AuthFormHeaders() :
                        HeaderHelpers.ContentHttpHeaders();

        return this._http.delete(uri, {headers})
            .toPromise()
            .then((response) => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected doSort(order: SortOrder, uri: string, useAuthToken: Boolean = true) {
        let body = JSON.stringify(order);
        let headers = useAuthToken ?
                        HeaderHelpers.AuthFormHeaders() :
                        HeaderHelpers.ContentHttpHeaders();
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
                        HeaderHelpers.AuthFormDataHeaders() :
                        HeaderHelpers.FormDataHeaders();

        return this._http.post(uri, formData, { headers })
            .toPromise()
            .then((response) => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected extractJsonResponse(res: Object): any {
        let response = <JsonResponse> res;
        if (!response.ok) {
            return new ErrorInfo({
                message: response.message,
                error: null
            });
        }
        return response.data;
    }

    protected extractArray<T>(res: Object, showprogress: boolean = true): any {
        return res as T[] || [];
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
}
