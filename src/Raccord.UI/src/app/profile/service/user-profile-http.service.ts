import { Injectable } from "@angular/core";
import { BaseHttpService } from "../../shared/service/base-http.service";
import { Http } from "@angular/http";
import { AppSettings } from "../../app.settings";
import { UserProfile } from "../model/user-profile.model";
import { Base64Image } from "../../shared/model/base-64-image.model";
import { UserProfileSummary } from "../model/user-profile-summary.model";

@Injectable()
export class UserProfileHttpService extends BaseHttpService {

  constructor(protected _http: Http) { 
      super(_http);
      this._baseUri = `${AppSettings.API_ENDPOINT}/userprofile`;
  }

  get(): Promise<UserProfile>{

    let uri = `${this._baseUri}`;

    return this.doGet(uri);
  }

  getSummary(): Promise<UserProfileSummary>{

    let uri = `${this._baseUri}/summary`;

    return this.doGet(uri);
  }

  post(profile: UserProfile): Promise<UserProfile> {
    let uri = this._baseUri;

    return this.doPost(profile, uri);
  }

  public uploadImage(files: File[]) {
    let uri = `${this._baseUri}/image`;

    return this.doFilePost(files, null, uri);
  }

  public removeImage() {
    let uri = `${this._baseUri}/image`;

    return this.doDelete(uri);
  }

  getBase64(userId: string): Promise<Base64Image> {

    let uri = `${this._baseUri}/image/${userId}/base64`;

    return this.doGet(uri);
  }
}
