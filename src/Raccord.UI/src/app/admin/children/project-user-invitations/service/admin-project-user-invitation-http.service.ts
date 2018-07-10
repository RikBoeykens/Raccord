import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import {
    ProjectUserInvitationUserInvitation,
    FullProjectUserInvitation,
    ProjectUserInvitationSummary,
    ProjectUserInvitation,
    ProjectUserInvitationProject
} from '../../../../shared/children/user-invitations';

@Injectable()
export class AdminProjectUserInvitationHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/projectuserinvitations`;
    }

    public getProjects(id: string): Promise<ProjectUserInvitationProject[] | void> {
        const uri = `${this._baseUri}/${id}/projects`;

        return this.doGetArray(uri);
    }

    public getUserInvitations(id: number): Promise<ProjectUserInvitationUserInvitation[] | void> {
        const uri = `${this._baseUri}/${id}/invitations`;

        return this.doGetArray(uri);
    }

    public get(id: number): Promise<FullProjectUserInvitation | void> {

        const uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(id: number): Promise<ProjectUserInvitationSummary | void> {

        const uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    public add(project: ProjectUserInvitation): Promise<number> {
        const uri = `${this._baseUri}/create`;

        return this.doPost(project, uri);
    }

    public update(project: ProjectUserInvitation): Promise<number> {
        const uri = `${this._baseUri}/update`;

        return this.doPost(project, uri);
    }

    public delete(id: number): Promise<any> {
        const uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
