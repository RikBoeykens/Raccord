import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { ShootingDay } from '../model/shooting-day.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';

@Injectable()
export class ShootingDayHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/shootingdays`;
    }

    getAvailable(projectId): Promise<ShootingDay[]> {

        var uri = `${this._baseUri}/${projectId}/available`;

        return this.doGetArray(uri);
    }

    getAll(projectId): Promise<ShootingDay[]> {
        
        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }
}
