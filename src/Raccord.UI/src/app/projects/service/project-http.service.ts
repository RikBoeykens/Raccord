import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { FullProject } from '../model/full-project.model';
import { ProjectSummary } from '../model/project-summary.model';
import { Project } from '../model/project.model';
import { JsonResponse } from '../../shared/model/json-response.model';
import { UserProject } from '../model/user-project.model';
import { UserProjectSummary } from '../model/user-project-summary.model';

@Injectable()
export class ProjectHttpService extends BaseHttpService {

    constructor(protected _http: Http) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/projects`;
    }

    public getAll(): Promise<UserProject[]> {

        let uri = this._baseUri;

        return this.doGetArray(uri);
    }

    public getSummaries(): Promise<UserProjectSummary[]> {

        let uri = `${this._baseUri}/summary`;

        return this.doGetArray(uri);
    }

    public get(id: number): Promise<FullProject>{

        let uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(id: Number): Promise<ProjectSummary> {

        let uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    public post(project: Project): Promise<Number> {
        let uri = this._baseUri;

        return this.doPost(project, uri);
    }

    public delete(id: Number): Promise<any> {
        let uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
