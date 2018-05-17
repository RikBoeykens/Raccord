import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { ChartInfo } from '../model/chart-info.model';
import { AppSettings } from '../../app.settings';
import { AuthService } from '../../security/service/auth.service';

@Injectable()
export class ChartHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ENDPOINT}/charts`;
    }

    getForProject(projectId): Promise<ChartInfo[]> {

        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }
}
