import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { ProjectUserInvitationSummary } from '../model/project-user-invitation-summary.model';
import { ProjectUserInvitation } from '../model/project-user-invitation.model';

@Injectable()
export class AdminProjectUserInvitationHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/projectuserinvitations`;
    }

    public getAll(id: string): Promise<ProjectUserInvitationSummary[] | void> {

        let uri = `${this._baseUri}/${id}/projects`;

        return this.doGetArray(uri);
    }

    public get(id: number): Promise<ProjectUserInvitationSummary | void> {

        let uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public add(project: ProjectUserInvitation): Promise<Number> {
        let uri = `${this._baseUri}/create`;

        return this.doPost(project, uri);
    }

    public update(project: ProjectUserInvitation): Promise<Number> {
        let uri = `${this._baseUri}/update`;

        return this.doPost(project, uri);
    }

    public delete(id: number): Promise<any> {
        let uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
