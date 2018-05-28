import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../app.settings';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { FullAdminCrewUnit } from
  '../../../projects/children/crew/crew-units/model/full-admin-crew-unit.model';

@Injectable()
export class AdminCrewUnitHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/crewunits`;
    }

    public get(id: number): Promise<FullAdminCrewUnit | void> {

        let uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }
}
