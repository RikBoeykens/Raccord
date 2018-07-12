import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../app.settings';
import { AdminDashboard } from '../model/admin-dashboard.model';

@Injectable()
export class AdminDashboardHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/dashboard`;
  }

  public get(): Promise<AdminDashboard | void> {

    const uri = `${this._baseUri}`;

    return this.doGet(uri);
  }
}
