import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { ChartInfo } from '..';

@Injectable()
export class ChartHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/charts`;
    }

    public getForProject(projectId): Promise<ChartInfo[] | void> {

        const uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }
}
