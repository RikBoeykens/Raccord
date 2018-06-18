import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HeaderHelpers } from '../helpers/header.helper';
import { JsonResponse } from '../model/json-response.model';
import { ErrorInfo } from '../model/error-info.model';
import { SortOrder } from '../model/sort-order.model';
import { PageRequest, PageRequestHelpers, PagedData } from '../children/paging';

@Injectable()
export abstract class BaseHttpService {

    protected _baseUri: string;

    constructor(
        protected _http: HttpClient
    ) {
    }

    protected doGetArray<T>(uri: string, useAuthToken: boolean = true): Promise<T[] | void> {
      const headers = useAuthToken ? HeaderHelpers.AuthJsonHeaders() : HeaderHelpers.JsonHeaders();
      return this._http.get(uri, {headers})
        .toPromise()
        .then((response) => this.extractArray<T>(response))
        .catch(this.handleErrorPromise);
    }

    protected doGetPaged<T>(
        uri: string,
        paginationRequest: PageRequest,
        useAuthToken: boolean = true
    ): Promise<PagedData<T> | void> {
        uri += `?${PageRequestHelpers.ConstructParams(paginationRequest)}`;
        const headers = useAuthToken ?
            HeaderHelpers.AuthJsonHeaders() :
            HeaderHelpers.JsonHeaders();
        return this._http.get(uri, {headers})
            .toPromise()
            .then((response) => this.extractJsonResponse<PagedData<T>>(response))
            .catch(this.handleErrorPromise);
    }

    protected doGet<T>(uri: string, useAuthToken: boolean = true) {
      const headers = useAuthToken ? HeaderHelpers.AuthJsonHeaders() : HeaderHelpers.JsonHeaders();
      return this._http.get(uri, {headers})
        .toPromise()
        .then((response: T) => response)
        .catch(this.handleErrorPromise);
    }

    protected doPost(object: any, uri: string, useAuthToken: boolean = true) {
      const body = JSON.stringify(object);
      const headers = HeaderHelpers.AuthFormHeaders();
      return this._http.post(uri, body, {headers})
        .toPromise()
        .then((response) => this.extractJsonResponse(response))
        .catch(this.handleErrorPromise);
    }

    protected doDelete(uri: string, useAuthToken: boolean = true) {
      const headers = useAuthToken ?
                      HeaderHelpers.AuthFormHeaders() :
                      HeaderHelpers.ContentHttpHeaders();

      return this._http.delete(uri, {headers})
          .toPromise()
          .then((response) => this.extractJsonResponse(response))
          .catch(this.handleErrorPromise);
    }

    protected doSort(order: SortOrder, uri: string, useAuthToken: boolean = true) {
      const body = JSON.stringify(order);
      const headers = useAuthToken ?
                      HeaderHelpers.AuthFormHeaders() :
                      HeaderHelpers.ContentHttpHeaders();
      return this._http.post(uri, body, { headers })
          .toPromise()
          .then((response) => this.extractJsonResponse(response))
          .catch(this.handleErrorPromise);
    }

    protected doFilePost(files: File[], object: any, uri: string, useAuthToken: boolean = true) {
      const formData = new FormData();
      for (const file of files) {
          formData.append('files', file, file.name);
      }
      for (const property in object) {
          if (Object.prototype.hasOwnProperty.call(object, property)) {
              formData.append(property, object[property]);
          }
      }
      const headers = useAuthToken ?
                      HeaderHelpers.AuthFormDataHeaders() :
                      HeaderHelpers.FormDataHeaders();

      return this._http.post(uri, formData, { headers })
          .toPromise()
          .then((response) => this.extractJsonResponse(response))
          .catch(this.handleErrorPromise);
    }

    protected extractJsonResponse<T>(res: any): any {
      const response = res as JsonResponse;
      if (!response.ok) {
          return new ErrorInfo({
              message: response.message,
              error: null
          });
      }
      return response.data as T;
    }

    protected extractArray<T>(res: any, showprogress: boolean = true): any {
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
