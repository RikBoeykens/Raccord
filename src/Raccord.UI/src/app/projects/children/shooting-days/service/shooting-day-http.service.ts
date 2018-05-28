import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { ShootingDay } from '../model/shooting-day.model';
import { JsonResponse } from '../../../../shared/model/json-response.model';
import { ShootingDaySummary } from '../model/shooting-day-summary.model';
import { FullShootingDay } from '../model/full-shooting-day.model';
import { ShootingDayCrewUnit } from '../model/shooting-day-crew-unit.model';

@Injectable()
export class ShootingDayHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/shootingdays`;
    }

    public getAvailableForCallsheet(projectId): Promise<ShootingDayCrewUnit[] | void> {

        let uri = `${this._baseUri}/${projectId}/available/callsheet`;

        return this.doGetArray<ShootingDayCrewUnit>(uri);
    }

    public getAvailableForCompletion(projectId): Promise<ShootingDayCrewUnit[] | void> {

        let uri = `${this._baseUri}/${projectId}/available/completion`;

        return this.doGetArray<ShootingDayCrewUnit>(uri);
    }

    public getCompleted(projectId): Promise<ShootingDaySummary[] | void> {

        let uri = `${this._baseUri}/${projectId}/completed`;

        return this.doGetArray<ShootingDaySummary>(uri);
    }

    public getAll(crewUnitId): Promise<ShootingDay[] | void> {

        let uri = `${this._baseUri}/${crewUnitId}/crewunit`;

        return this.doGetArray<ShootingDay>(uri);
    }
    public get(id: number): Promise<FullShootingDay | void> {

        let uri = `${this._baseUri}/${id}`;

        return this.doGet<FullShootingDay>(uri);
    }

    public getSummary(id: Number): Promise<ShootingDaySummary | void> {

        let uri = `${this._baseUri}/${id}/summary`;

        return this.doGet<ShootingDaySummary>(uri);
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
