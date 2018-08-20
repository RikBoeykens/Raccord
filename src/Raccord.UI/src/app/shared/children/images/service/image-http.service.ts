import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../service/base-http.service';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../../app.settings';
import { Base64Image } from '../../..';

@Injectable()
export class ImageHttpService extends BaseHttpService {

  constructor(protected _http: HttpClient) {
      super(_http);
      this._baseUri = `${AppSettings.API_ENDPOINT}/images`;
  }

  public getBase64(id: number): Promise<Base64Image> {
    const uri = `${this._baseUri}/${id}/base64`;

    return this.doGet(uri).then((data) => data as Base64Image);
  }
}
