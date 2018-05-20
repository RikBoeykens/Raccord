import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { AppSettings } from '../../../app.settings';
import { FullProject } from '../../../projects';
import { ProjectSummary } from '../../../projects';
import { Project } from '../../../projects';

@Injectable()
export class AdminProjectHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/projects`;
    }

    getAll(): Promise<ProjectSummary[] | void> {

        var uri = this._baseUri;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullProject | void>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<ProjectSummary | void> {

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
