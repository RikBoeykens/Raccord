import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserPermissionSummary } from '../../users/permissions/model/user-permission-summary.model';
import { AppSettings } from '../../../../app.settings';
import { BaseHttpService } from '../../../service/base-http.service';

@Injectable()
export class AccountHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/account`;
    }

    public getProjectPermissions(): Promise<UserPermissionSummary | void> {

        const uri = `${this._baseUri}/permissions`;

        return this.doGet(uri);
    }
}
