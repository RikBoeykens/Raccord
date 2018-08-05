import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import {
  BreakdownItem,
  FullBreakdownItem,
  BreakdownItemSummary,
  SearchBreakdownItemRequest
} from '../../../../..';

@Injectable()
export class BreakdownItemHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/breakdownitems`;
    }

    public getAll(typeId): Promise<BreakdownItem[] | void> {

      const uri = `${this._baseUri}/${typeId}/type`;

      return this.doGetArray(uri);
    }

    public get(id: number): Promise<FullBreakdownItem | void> {

      const uri = `${this._baseUri}/${id}`;

      return this.doGet(uri);
    }

    public getSummary(id: number): Promise<BreakdownItemSummary | void> {

      const uri = `${this._baseUri}/${id}/summary`;

      return this.doGet(uri);
    }

    public post(breakdownItem: BreakdownItem): Promise<number> {
      const uri = this._baseUri;

      return this.doPost(breakdownItem, uri);
    }

    public delete(id: number): Promise<any> {
      const uri = `${this._baseUri}/${id}`;

      return this.doDelete(uri);
    }

    public merge(toId: number, mergeId): Promise<any> {
      const uri = `${this._baseUri}/merge/${toId}/${mergeId}`;

      return this.doPost(null, uri);
    }

    public searchByType(request: SearchBreakdownItemRequest): Promise<BreakdownItem[]> {

      const uri = `${this._baseUri}/search`;

      return this.doPost(request, uri);
    }
}
