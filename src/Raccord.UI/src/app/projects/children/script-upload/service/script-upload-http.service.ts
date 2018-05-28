import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from "../../../../shared/service/base-http.service";
import { AppSettings } from "../../../../app.settings";
import { FullScriptUpload } from "../model/full-script-upload.model";

@Injectable()
export class ScriptUploadHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ENDPOINT}/scriptuploads`;
  }

  public get(id: number): Promise<FullScriptUpload | void> {

    let uri = `${this._baseUri}/${id}`;

    return this.doGet(uri);
  }

  public upload(files: File[], projectId: number)
  {
      let uri = `${this._baseUri}/${projectId}/upload`;

      return this.doFilePost(files, null, uri);
  }
}
