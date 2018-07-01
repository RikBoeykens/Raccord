import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../../../service/base-http.service';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../../../../app.settings';
import { UserProfile } from '../model/user-profile.model';
import { UserProfileSummary } from '../model/user-profile-summary.model';
import { Base64Image } from '../../../../../model/base-64.image.model';

@Injectable()
export class UserProfileHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ENDPOINT}/userprofile`;
  }

  public get(): Promise<UserProfile | void> {

    const uri = `${this._baseUri}`;

    return this.doGet(uri);
  }

  public getSummary(): Promise<UserProfileSummary | void> {

    const uri = `${this._baseUri}/summary`;

    return this.doGet(uri);
  }

  public post(profile: UserProfile): Promise<UserProfile> {
    const uri = this._baseUri;

    return this.doPost(profile, uri);
  }

  public uploadImage(files: File[]) {
    const uri = `${this._baseUri}/image`;

    return this.doFilePost(files, null, uri);
  }

  public removeImage() {
    const uri = `${this._baseUri}/image`;

    return this.doDelete(uri);
  }

  public getBase64(userId: string): Promise<Base64Image | void> {

    const uri = `${this._baseUri}/image/${userId}/base64`;

    return this.doGet(uri);
  }
}
