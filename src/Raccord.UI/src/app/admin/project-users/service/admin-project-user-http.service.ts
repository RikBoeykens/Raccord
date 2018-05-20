import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../app.settings';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { ProjectUser } from '../model/project-user.model';
import { FullProjectUser } from '../model/full-project-user.model';
import { ProjectUserUser } from '../model/project-user-user.model';
import { ProjectUserProject } from '../model/project-user-project.model';

@Injectable()
export class AdminProjectUserHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/projectusers`;
    }

    public getProjects(id): Promise<ProjectUserProject[] | void> {

        let uri = `${this._baseUri}/${id}/projects`;
        return this.doGetArray(uri);
    }

    public getUsers(id): Promise<ProjectUserUser[] | void> {

        let uri = `${this._baseUri}/${id}/users`;
        return this.doGetArray(uri);
    }

    public get(id: number): Promise<FullProjectUser | void> {

        let uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public post(projectUser: ProjectUser): Promise<number> {
        let uri = this._baseUri;

        return this.doPost(projectUser, uri);
    }

    public delete(id: Number): Promise<any> {
        let uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
