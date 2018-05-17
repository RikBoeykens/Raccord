import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { ShootingDay } from '../model/shooting-day.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { ShootingDaySummary } from '../model/shooting-day-summary.model';
import { FullShootingDay } from '../model/full-shooting-day.model';
import { ShootingDayCrewUnit } from '../model/shooting-day-crew-unit.model';
import { AuthService } from '../../../../security/service/auth.service';

@Injectable()
export class ShootingDayHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ENDPOINT}/shootingdays`;
    }

    public getAvailableForCallsheet(projectId): Promise<ShootingDayCrewUnit[]> {

        let uri = `${this._baseUri}/${projectId}/available/callsheet`;

        return this.doGetArray(uri);
    }

    public getAvailableForCompletion(projectId): Promise<ShootingDayCrewUnit[]> {

        let uri = `${this._baseUri}/${projectId}/available/completion`;

        return this.doGetArray(uri);
    }

    public getCompleted(projectId): Promise<ShootingDaySummary[]> {

        let uri = `${this._baseUri}/${projectId}/completed`;

        return this.doGetArray(uri);
    }

    public getAll(crewUnitId): Promise<ShootingDay[]> {

        let uri = `${this._baseUri}/${crewUnitId}/crewunit`;

        return this.doGetArray(uri);
    }
    public get(id: number): Promise<FullShootingDay> {

        let uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(id: Number): Promise<ShootingDaySummary> {

        let uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    public prepareCompletion(id: Number): Promise<number> {
        let uri = `${this._baseUri}/${id}/preparecompletion`;

        return this.doPost(null, uri);
    }

    public post(shootingDay: ShootingDay): Promise<number> {
        let uri = this._baseUri;

        return this.doPost(shootingDay, uri);
    }
}
