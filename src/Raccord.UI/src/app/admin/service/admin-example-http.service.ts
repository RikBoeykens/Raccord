import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../shared/service/base-http.service';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../app.settings';
import { AdminCreateExample } from '../model/admin-create-example.model';

@Injectable()
export class AdminExampleHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/example`;
  }

  public post(project: AdminCreateExample): Promise<number> {
    const uri = this._baseUri;

    return this.doPost(project, uri);
  }
}
