import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { AppSettings } from '../../../app.settings';
import { BaseHttpService } from "../../../shared/service/base-http.service";
import { ProjectUser } from '../model/project-user.model';
import { FullProjectUser } from '../model/full-project-user.model';
import { ProjectUserUser } from '../model/project-user-user.model';
import { ProjectUserProject } from '../model/project-user-project.model';

@Injectable()
export class AdminProjectUserHttpService extends BaseHttpService {

    constructor(protected _http: Http) { 
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/projectusers`;
    }

    getProjects(id): Promise<ProjectUserProject[]> {

        var uri = `${this._baseUri}/${id}/projects`;
        console.log("getting projects");
        return this.doGetArray(uri);
    }

    getUsers(id): Promise<ProjectUserUser[]> {

        var uri = `${this._baseUri}/${id}/users`;
        console.log("getting users");
        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullProjectUser>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    post(projectUser: ProjectUser): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(projectUser, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}