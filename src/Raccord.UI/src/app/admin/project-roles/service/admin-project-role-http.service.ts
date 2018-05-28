import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../app.settings';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { ProjectRole } from '../model/project-role.model';

@Injectable()
export class AdminProjectRoleHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/projectroles`;
    }

    public get(): Promise<ProjectRole[] | void> {
        let uri = this._baseUri;
        return this.doGetArray(uri);
    }
}