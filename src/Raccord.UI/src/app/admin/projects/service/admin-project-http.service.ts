import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { AppSettings } from '../../../app.settings';
import { FullProject } from '../../../projects';
import { ProjectSummary } from '../../../projects';
import { Project } from '../../../projects';
import { AuthService } from '../../../security/service/auth.service';

@Injectable()
export class AdminProjectHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/projects`;
    }

    getAll(): Promise<ProjectSummary[]> {

        var uri = this._baseUri;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullProject>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<ProjectSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(project: Project): Promise<Number> {
        var uri = this._baseUri;

        return this.doPost(project, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
