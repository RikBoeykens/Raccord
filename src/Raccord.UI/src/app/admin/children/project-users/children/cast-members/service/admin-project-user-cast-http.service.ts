import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';

@Injectable()
export class AdminProjectUserCastHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/projectusercast`;
  }

  public addLink(projectUserId: number, castMemberId: number): Promise<any> {
    const uri = `${this._baseUri}/${projectUserId}/${castMemberId}/addlink`;

    return this.doPost(null, uri);
  }

  public removeLink(projectUserId: number, castMemberId: number): Promise<any> {
    const uri = `${this._baseUri}/${projectUserId}/${castMemberId}/removelink`;

    return this.doPost(null, uri);
  }
}
