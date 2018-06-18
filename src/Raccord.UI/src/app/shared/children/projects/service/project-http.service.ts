import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../service/base-http.service';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../../app.settings';
import { UserProject } from '../model/user-project.model';
import { UserProjectSummary } from '../model/user-project-summary.model';
import { FullProject } from '../model/full-project.model';
import { ProjectSummary } from '../model/project-summary.model';
import { Project } from '../model/project.model';
import { PageRequest, PagedData } from '../../paging';

@Injectable()
export class ProjectHttpService extends BaseHttpService {

    constructor(
      protected _http: HttpClient
    ) {
      super(_http);
      this._baseUri = `${AppSettings.API_ENDPOINT}/projects`;
    }

    public getAll(): Promise<UserProject[] | void> {

      const uri = this._baseUri;

      return this.doGetArray<UserProject>(uri);
    }

    public getSummaries(): Promise<UserProjectSummary[] | void> {

      const uri = `${this._baseUri}/summary`;

      return this.doGetArray<UserProjectSummary>(uri);
    }

    public getPaged(
      pageRequest: PageRequest
    ): Promise<PagedData<UserProject> | void> {

      const uri = `${this._baseUri}/paged`;

      return this.doGetPaged<UserProject>(uri, pageRequest);
    }

    public get(id: number): Promise<FullProject | void> {

      const uri = `${this._baseUri}/${id}`;

      return this.doGet<FullProject>(uri);
    }

    public getSummary(id: number): Promise<ProjectSummary | void> {
      const uri = `${this._baseUri}/${id}/summary`;

      return this.doGet<ProjectSummary>(uri);
    }

    public post(project: Project): Promise<number | void | string> {
      const uri = this._baseUri;

      return this.doPost(project, uri);
    }

    public delete(id: number): Promise<any> {
        const uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
