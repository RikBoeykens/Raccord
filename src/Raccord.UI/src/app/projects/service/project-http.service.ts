import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { FullProject } from '../model/full-project.model';
import { ProjectSummary } from '../model/project-summary.model';
import { Project } from '../model/project.model';
import { JsonResponse } from '../../shared/model/json-response.model';
import { UserProject } from '../model/user-project.model';

@Injectable()
export class ProjectHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/projects`;
    }

    getAll(): Promise<UserProject[]> {

        var uri = this._baseUri;

        return this.doGetArray(uri);
    }

    getSummaries(): Promise<ProjectSummary[]> {

        var uri = `${this._baseUri}/summary`;

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
