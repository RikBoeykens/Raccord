import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { AppSettings } from '../../app.settings';
import { UserInvitation } from '../model/user-invitation.model';
import { CreateUserFromInvitation } from '../model/create-user-from-invitation.model';
import { CreateUserResult } from '../model/create-user-result.model';

@Injectable()
export class InvitationHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/invitations`;
    }

    public get(id: string): Promise<UserInvitation | void> {

      console.log(`in service" ${id}`);
      let uri = `${this._baseUri}/${id}`;
      return this.doGet(uri, false);
    }

    public createUser(request: CreateUserFromInvitation): Promise<CreateUserResult> {
      let uri = this._baseUri;

      return this.doPost(request, uri, false);
    }
}
