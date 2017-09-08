import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { ShootingDay } from '../model/shooting-day.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { ShootingDaySummary } from "../model/shooting-day-summary.model";
import { FullShootingDay } from "../model/full-shooting-day.model";

@Injectable()
export class ShootingDayHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/shootingdays`;
    }

    getAvailableForCallsheet(projectId): Promise<ShootingDay[]> {

        var uri = `${this._baseUri}/${projectId}/available/callsheet`;

        return this.doGetArray(uri);
    }
    
    getAvailableForCompletion(projectId): Promise<ShootingDay[]> {

        var uri = `${this._baseUri}/${projectId}/available/completion`;

        return this.doGetArray(uri);
    }
    
    getCompleted(projectId): Promise<ShootingDaySummary[]> {

        var uri = `${this._baseUri}/${projectId}/completed`;

        return this.doGetArray(uri);
    }

    getAll(projectId): Promise<ShootingDay[]> {
        
        var uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }
    get(id: number): Promise<FullShootingDay>{
        
        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<ShootingDaySummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }
    
    prepareCompletion(id: Number): Promise<number> {
        var uri = `${this._baseUri}/${id}/preparecompletion`;

        return this.doPost(null, uri);
    }

    post(shootingDay: ShootingDay): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(shootingDay, uri);
    }
}
