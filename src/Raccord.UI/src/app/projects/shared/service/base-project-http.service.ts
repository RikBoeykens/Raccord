import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { AppSettings } from '../../../app.settings';
import { AuthService } from '../../../security';

@Injectable()
export class BaseProjectHttpService extends BaseHttpService {
  protected controllerName: string;

  constructor(
      protected _http: HttpClient,
      protected _authService: AuthService,
      controllerName: string) {
      super(_http, _authService);
      this._baseUri = `${AppSettings.API_PROJECT_ENDPOINT}`;
      this.controllerName = controllerName;
  }

  protected getUri(projectId: number) {
      return `${this._baseUri}/${projectId}/${this.controllerName}`;
  }
}
