import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { UserInvitationSummary } from '../../shared/children/user-invitations';
import { CreateUserFromInvitation, CreateUserResult } from '..';

@Injectable()
export class InvitationHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/invitations`;
    }

    public get(id: string): Promise<UserInvitationSummary | void> {
      const uri = `${this._baseUri}/${id}`;
      return this.doGet(uri, false);
    }

    public createUser(request: CreateUserFromInvitation): Promise<CreateUserResult> {
      const uri = this._baseUri;

      return this.doPost(request, uri, false);
    }
}
