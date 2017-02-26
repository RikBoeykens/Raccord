import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { JsonResponse } from '../model/json-response.model';
import { SortOrder } from '../model/sort-order.model';
import 'rxjs/add/operator/toPromise';

@Injectable()
export abstract class BaseHttpService{

    protected _baseUri: string;

    constructor(protected _http: Http) {
    }    
    
    protected doGetArray(uri: string){
        return this._http.get(uri)
            .toPromise()
            .then(response => this.extractArray(response))
            .catch(this.handleErrorPromise);
    }

    protected doGet(uri: string){
        return this._http.get(uri)
            .toPromise()
            .then(response => response.json())
            .catch(this.handleErrorPromise);
    }

    protected doPost(object: any, uri: string){

        let body = JSON.stringify(object);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this._http.post(uri, body, options)
            .toPromise()
            .then(response => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected doDelete(uri: string){
        
        return this._http.delete(uri)
            .toPromise()
            .then(response => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected doSort(order: SortOrder, uri: string){
        let body = JSON.stringify(order);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this._http.post(uri, body, options)
            .toPromise()
            .then(response => this.extractJsonResponse(response))
            .catch(this.handleErrorPromise);
    }

    protected doFilePost(files: File[], object: any, uri: string){
        let formData = new FormData();
        for (let i = 0; i < files.length; i++) {
            formData.append("files", files[i], files[i].name);
        }
        return this._http.post(uri, formData)
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