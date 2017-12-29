import { Injectable } from "@angular/core";
import { BaseHttpService } from "../../shared/service/base-http.service";
import { Http } from "@angular/http";
import { AppSettings } from "../../app.settings";
import { UserProfile } from "../model/user-profile.model";

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

  post(profile: UserProfile): Promise<UserProfile> {
    let uri = this._baseUri;

    return this.doPost(profile, uri);
  }
}