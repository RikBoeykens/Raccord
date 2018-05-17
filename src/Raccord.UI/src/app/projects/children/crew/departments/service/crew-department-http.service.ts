import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { FullCrewDepartment } from '../model/full-crew-department.model';
import { AuthService } from '../../../../../security/service/auth.service';

@Injectable()
export class CrewDepartmentHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ENDPOINT}/crewdepartments`;
    }

    public getAll(crewUnitId): Promise<FullCrewDepartment[]> {

        const uri = `${this._baseUri}/${crewUnitId}/unit`;

        return this.doGetArray(uri);
    }
}