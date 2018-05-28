import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { ChartInfo } from '../model/chart-info.model';
import { AppSettings } from '../../app.settings';

@Injectable()
export class ChartHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/charts`;
    }

    getForProject(projectId): Promise<ChartInfo[] | void> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }
}
