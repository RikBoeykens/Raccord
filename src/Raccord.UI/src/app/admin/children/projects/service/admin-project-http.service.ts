import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { ProjectSummary, FullProject, Project } from '../../../../shared/children/projects';

@Injectable()
export class AdminProjectHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/projects`;
  }

  public getAll(): Promise<ProjectSummary[] | void> {

    const uri = this._baseUri;

    return this.doGetArray(uri);
  }

  public get(id: number): Promise<FullProject | void> {

    const uri = `${this._baseUri}/${id}`;

    return this.doGet(uri);
  }

  public getSummary(id: number): Promise<ProjectSummary | void> {

    const uri = `${this._baseUri}/${id}/summary`;

    return this.doGet(uri);
  }

  public post(project: Project): Promise<number> {
    const uri = this._baseUri;

    return this.doPost(project, uri);
  }

  public delete(id: number): Promise<any> {
    const uri = `${this._baseUri}/${id}`;

    return this.doDelete(uri);
  }
}
