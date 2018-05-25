import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { AppSettings } from '../../../app.settings';
import { UserInvitationSummary } from '../../../invitations/model/user-invitation-summary.model';
import { FullUserInvitation } from '../../../invitations/model/full-user-invitation.model';
import { UserInvitation } from '../../../invitations/model/user-invitation.model';
import { UserInvitationResult } from '../../../invitations/model/user-invitation-result.model';

@Injectable()
export class AdminUserInvitationHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/userinvitations`;
    }

    public getAll(): Promise<UserInvitationSummary[] | void> {

        let uri = this._baseUri;

        return this.doGetArray(uri);
    }

    public get(id: string): Promise<FullUserInvitation | void> {

        let uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(id: string): Promise<UserInvitationSummary | void> {

        let uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    public add(project: UserInvitation): Promise<UserInvitationResult> {
        let uri = `${this._baseUri}/create`;

        return this.doPost(project, uri);
    }

    public update(project: UserInvitation): Promise<UserInvitationResult> {
        let uri = `${this._baseUri}/update`;

        return this.doPost(project, uri);
    }

    public delete(id: string): Promise<any> {
        let uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
