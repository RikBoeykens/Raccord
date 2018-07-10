import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../../app.settings';
import {
  UserInvitationSummary, FullUserInvitation, UserInvitation, UserInvitationResult
} from '../../../../shared/children/user-invitations';

@Injectable()
export class AdminUserInvitationHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/userinvitations`;
    }

    public getAll(): Promise<UserInvitationSummary[] | void> {

      const uri = this._baseUri;

      return this.doGetArray(uri);
    }

    public get(id: string): Promise<FullUserInvitation | void> {

      const uri = `${this._baseUri}/${id}`;

      return this.doGet(uri);
    }

    public getSummary(id: string): Promise<UserInvitationSummary | void> {

      const uri = `${this._baseUri}/${id}/summary`;

      return this.doGet(uri);
    }

    public add(project: UserInvitation): Promise<UserInvitationResult> {
      const uri = `${this._baseUri}/create`;

      return this.doPost(project, uri);
    }

    public update(project: UserInvitation): Promise<UserInvitationResult> {
      const uri = `${this._baseUri}/update`;

      return this.doPost(project, uri);
    }

    public delete(id: string): Promise<any> {
      const uri = `${this._baseUri}/${id}`;

      return this.doDelete(uri);
    }
}
