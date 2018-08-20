import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import {
    ShootingDay,
    ShootingDayCrewUnit,
    ShootingDaySummary,
    FullShootingDay
} from '../../../../..';

@Injectable()
export class ShootingDayHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/shootingdays`;
    }

    public getAvailableForCallsheet(projectId): Promise<ShootingDayCrewUnit[] | void> {

        const uri = `${this._baseUri}/${projectId}/available/callsheet`;

        return this.doGetArray<ShootingDayCrewUnit>(uri);
    }

    public getAvailableForCompletion(projectId): Promise<ShootingDayCrewUnit[] | void> {

        const uri = `${this._baseUri}/${projectId}/available/completion`;

        return this.doGetArray<ShootingDayCrewUnit>(uri);
    }

    public getCompleted(projectId): Promise<ShootingDayCrewUnit[] | void> {

        const uri = `${this._baseUri}/${projectId}/completed`;

        return this.doGetArray<ShootingDayCrewUnit>(uri);
    }

    public getAll(crewUnitId): Promise<ShootingDay[] | void> {

        const uri = `${this._baseUri}/${crewUnitId}/crewunit`;

        return this.doGetArray<ShootingDay>(uri);
    }
    public get(id: number): Promise<FullShootingDay | void> {

        const uri = `${this._baseUri}/${id}`;

        return this.doGet<FullShootingDay>(uri);
    }

    public getSummary(id: number): Promise<ShootingDaySummary | void> {

        const uri = `${this._baseUri}/${id}/summary`;

        return this.doGet<ShootingDaySummary>(uri);
    }

    public prepareCompletion(id: number): Promise<number> {
        const uri = `${this._baseUri}/${id}/preparecompletion`;

        return this.doPost(null, uri);
    }

    public post(shootingDay: ShootingDay): Promise<number> {
        const uri = this._baseUri;

        return this.doPost(shootingDay, uri);
    }
}
