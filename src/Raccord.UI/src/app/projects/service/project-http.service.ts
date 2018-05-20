import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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

    constructor(
        protected _http: HttpClient
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/projects`;
    }

    public getAll(): Promise<UserProject[] | void> {

        let uri = this._baseUri;

        return this.doGetArray<UserProject>(uri);
    }

    public getSummaries(): Promise<UserProjectSummary[] | void> {

        let uri = `${this._baseUri}/summary`;

        return this.doGetArray<UserProjectSummary>(uri);
    }

    public get(id: number): Promise<FullProject | void> {

        let uri = `${this._baseUri}/${id}`;

        return this.doGet<FullProject>(uri);
    }

    public getSummary(id: Number): Promise<ProjectSummary | void> {

        let uri = `${this._baseUri}/${id}/summary`;

        return this.doGet<ProjectSummary>(uri);
    }

    public post(project: Project): Promise<Number | void | string> {
        let uri = this._baseUri;

        return this.doPost(project, uri);
    }

    public delete(id: Number): Promise<any> {
        let uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
