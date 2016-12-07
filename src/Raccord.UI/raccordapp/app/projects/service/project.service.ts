import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { ProjectSummary } from '../model/project-summary.model';
import { Project } from '../model/project.model';
import { JsonResponse } from '../../shared/model/json-response.model';

@Injectable()
export class ProjectService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/projects`;
    }

    getAll(): Promise<ProjectSummary[]> {

        var uri = this._baseUri;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<Project>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<ProjectSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(project: ProjectSummary): Promise<Number> {
        var uri = this._baseUri;

        return this.doPost(project, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
