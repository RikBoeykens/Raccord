import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import {
  ProjectUserUser,
  ProjectUserProject,
  ProjectUser
} from '../../../../shared/children/users';
import { AdminFullProjectUser } from '../../..';

@Injectable()
export class AdminProjectUserHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/projectusers`;
  }

  public getProjects(id): Promise<ProjectUserProject[] | void> {

    const uri = `${this._baseUri}/${id}/projects`;
    return this.doGetArray(uri);
  }

  public getUsers(id): Promise<ProjectUserUser[] | void> {

    const uri = `${this._baseUri}/${id}/users`;
    return this.doGetArray(uri);
  }

  public get(id: number): Promise<AdminFullProjectUser | void> {

    const uri = `${this._baseUri}/${id}`;

    return this.doGet(uri);
  }

  public post(projectUser: ProjectUser): Promise<number> {
    const uri = this._baseUri;

    return this.doPost(projectUser, uri);
  }

  public delete(id: number): Promise<any> {
    const uri = `${this._baseUri}/${id}`;

    return this.doDelete(uri);
  }
}
