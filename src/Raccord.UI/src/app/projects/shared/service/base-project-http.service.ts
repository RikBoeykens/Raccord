import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { AppSettings } from '../../../app.settings';

@Injectable()
export class BaseProjectHttpService extends BaseHttpService {
  protected controllerName: string;

  constructor(protected _http: Http, controllerName: string) {
      super(_http);
      this._baseUri = `${AppSettings.API_PROJECT_ENDPOINT}`;
      this.controllerName = controllerName;
  }

  protected getUri(projectId: number) {
      return `${this._baseUri}/${projectId}/${this.controllerName}`;
  }
}
