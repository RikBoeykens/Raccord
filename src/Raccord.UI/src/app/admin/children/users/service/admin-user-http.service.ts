import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../../app.settings';
import { UserSummary, User } from '../../../../shared/children/users';
import { CreateUser, FullUser } from '../../..';

@Injectable()
export class AdminUserHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/users`;
  }

  public getAll(): Promise<UserSummary[] | void> {

    const uri = this._baseUri;

    return this.doGetArray(uri);
  }

  public get(id: string): Promise<FullUser | void> {

    const uri = `${this._baseUri}/${id}`;

    return this.doGet(uri);
  }

  public getSummary(id: string): Promise<UserSummary | void> {

    const uri = `${this._baseUri}/${id}/summary`;

    return this.doGet(uri);
  }

  public add(user: CreateUser): Promise<string> {
    const uri = `${this._baseUri}/create`;

    return this.doPost(user, uri);
  }

  public update(user: User): Promise<string> {
    const uri = `${this._baseUri}/update`;

    return this.doPost(user, uri);
  }

  public delete(id: string): Promise<any> {
    const uri = `${this._baseUri}/${id}`;

    return this.doDelete(uri);
  }
}
