import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { AppSettings } from '../../../app.settings';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { FullAdminCrewUnit } from
  '../../../projects/children/crew/crew-units/model/full-admin-crew-unit.model';
import { AuthService } from '../../../security/service/auth.service';

@Injectable()
export class AdminCrewUnitHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/crewunits`;
    }

    public get(id: number): Promise<FullAdminCrewUnit> {

        let uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }
}
