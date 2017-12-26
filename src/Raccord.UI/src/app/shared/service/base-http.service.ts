import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { JsonResponse } from '../model/json-response.model';
import { SortOrder } from '../model/sort-order.model';
import { HeaderHelpers } from "../helpers/header.helpers";
import 'rxjs/add/operator/toPromise';

@Injectable()
export abstract class BaseHttpService{

    protected _baseUri: string;

    constructor(protected _http: Http) {
    }    
    
    protected doGetArray(uri: string, useAuthToken: Boolean = true){
        let headers = useAuthToken ? HeaderHelpers.AuthJsonHeaders() : HeaderHelpers.JsonHeaders();
        let options = new RequestOptions({headers: headers});
        return this._http.get(uri, options)
            .toPromise()
            .then(response => this.extractArray(response))
            .catch(this.handleErrorPromise);
    }

    protected doGet(uri: string, useAuthToken: Boolean = true){
        let headers = useAuthToken ? HeaderHelpers.AuthJsonHeaders() : HeaderHelpers.JsonHeaders();
        let options = new RequestOptions({headers: headers});
        return this._http.get(uri, options)
            .toPromise()
            .then(response => response.json())
            .catch(this.handleErrorPromise);
    }

    protected doPost(object: any, uri: string, useAuthToken: Boolean = true){

        let body = JSON.stringify(object);
        let headers = useAuthToken ? HeaderHelpers.AuthFormHeaders() : HeaderHelpers.ContentHeaders();
        let options = new RequestOptions({headers: headers});

        return this._http.post(uri, body, options)
            .toPromise()
            .then(response => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected doDelete(uri: string, useAuthToken: Boolean = true){
        
        let headers = useAuthToken ? HeaderHelpers.AuthFormHeaders() : HeaderHelpers.ContentHeaders();
        let options = new RequestOptions({headers: headers});

        return this._http.delete(uri, options)
            .toPromise()
            .then(response => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected doSort(order: SortOrder, uri: string, useAuthToken: Boolean = true){
        let body = JSON.stringify(order);
        let headers = useAuthToken ? HeaderHelpers.AuthFormHeaders() : HeaderHelpers.ContentHeaders();
        let options = new RequestOptions({ headers: headers });

        return this._http.post(uri, body, options)
            .toPromise()
            .then(response => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected doFilePost(files: File[], object: any, uri: string, useAuthToken: Boolean = true){
        let formData = new FormData();
        console.log(files);
        for (let i = 0; i < files.length; i++) {
            formData.append("files", files[i], files[i].name);
        }
        for(var property in object){
            formData.append(property, object[property]);
        }
        
        let headers = useAuthToken ?
                        HeaderHelpers.AuthFormDataHeaders() :
                        HeaderHelpers.FormDataHeaders();
        let options = new RequestOptions({ headers });

        return this._http.post(uri, formData, options)
            .toPromise()
            .then(response => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected extractJsonResponse(res: Response) {

        let response = <JsonResponse>res.json();

        if (!response.ok) {
            return response.message;
        }

        return response.data;
    }

    protected extractArray(res: Response, showprogress: boolean = true) {
        let data = res.json();
        return data || [];
    }

    protected handleErrorPromise(error: any): Promise<void> {
        try {
            error = JSON.parse(error._body);
        } catch (e) {
        }

        let errMsg = error.errorMessage
            ? error.errorMessage
            : error.message
                ? error.message
                : error._body
                    ? error._body
                    : error.status
                        ? `${error.status} - ${error.statusText}`
                        : 'unknown server error';

        console.error(errMsg);
        return Promise.reject(errMsg);
    }
}