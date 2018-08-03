import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import { SceneSummary, Scene } from '../../../../../../shared/children/scenes';
import {
  PagedData,
  PageRequest,
  PageRequestHelpers
} from '../../../../../../shared/children/paging';
import { LinkedImage } from '../../../../../../shared/children/images';
import { SceneFilterRequest, FullScene } from '../../../../..';

@Injectable()
export class SceneHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ENDPOINT}/scenes`;
  }

  public getAll(projectId): Promise<SceneSummary[] | void> {

    const uri = `${this._baseUri}/${projectId}/project`;

    return this.doGetArray(uri);
  }

  public get(id: number): Promise<FullScene | void> {

    const uri = `${this._baseUri}/${id}`;

    return this.doGet(uri);
  }

  public getSummary(id: number): Promise<SceneSummary | void> {

    const uri = `${this._baseUri}/${id}/summary`;

    return this.doGet(uri);
  }

  public getImages(id: number): Promise<LinkedImage[] | void> {

    const uri = `${this._baseUri}/${id}/images`;

    return this.doGet(uri);
  }

  public post(scene: Scene): Promise<number> {
    const uri = this._baseUri;

    return this.doPost(scene, uri);
  }

  public delete(id: number): Promise<any> {
    const uri = `${this._baseUri}/${id}`;

    return this.doDelete(uri);
  }

  public filter(
    request: SceneFilterRequest,
    pageRequest: PageRequest
  ): Promise<PagedData<SceneSummary>> {

    const uri = `${this._baseUri}/filter?${PageRequestHelpers.ConstructParams(pageRequest)}`;

    return this.doPost(request, uri);
  }
}
