import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { BaseHttpService } from "../../../../shared/service/base-http.service";
import { AppSettings } from "../../../../app.settings";
import { SceneText } from "../model/scene-text.model";

@Injectable()
export class ScriptTextHttpService extends BaseHttpService {

  constructor(protected _http: Http) { 
      super(_http);
      this._baseUri = `${AppSettings.API_ENDPOINT}/scripttexts`;
  }

  public getForProject(id: number): Promise<SceneText[]> {

    let uri = `${this._baseUri}/${id}/project`;

    return this.doGetArray(uri);
  }

  public getForCallsheet(id: number): Promise<SceneText[]> {

    let uri = `${this._baseUri}/${id}/callsheet`;

    return this.doGetArray(uri);
  }

  public get(id: number): Promise<SceneText> {

    let uri = `${this._baseUri}/${id}`;

    return this.doGet(uri);
  }
}