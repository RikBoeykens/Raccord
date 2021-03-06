import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';

@Injectable()
export class AdminProjectUserInvitationCastHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/projectuserinvitationcast`;
  }

  public addLink(projectUserInvitationId: number, castMemberId: number): Promise<any> {
    const uri = `${this._baseUri}/${projectUserInvitationId}/${castMemberId}/addlink`;

    return this.doPost(null, uri);
  }

  public removeLink(projectUserInvitationId: number, castMemberId: number): Promise<any> {
    const uri = `${this._baseUri}/${projectUserInvitationId}/${castMemberId}/removelink`;

    return this.doPost(null, uri);
  }
}
