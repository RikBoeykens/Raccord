import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { CastMemberSummary, CastMember } from '../../../../shared/children/cast';
import { AdminFullCastMember } from '../../..';

@Injectable()
export class AdminCastMemberHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/castmembers`;
  }

  public getAll(projectId): Promise<CastMemberSummary[] | void> {

    const uri = `${this._baseUri}/${projectId}/project`;

    return this.doGetArray(uri);
  }

  public get(id: number): Promise<AdminFullCastMember | void> {

    const uri = `${this._baseUri}/${id}`;

    return this.doGet(uri);
  }

  public getSummary(id: number): Promise<CastMemberSummary | void> {

    const uri = `${this._baseUri}/${id}/summary`;

    return this.doGet(uri);
  }

  public post(castMember: CastMember): Promise<number> {
    const uri = this._baseUri;

    return this.doPost(castMember, uri);
  }

  public delete(id: number): Promise<any> {
    const uri = `${this._baseUri}/${id}`;

    return this.doDelete(uri);
  }

  public addLink(castMemberId: number, characterId: number): Promise<any> {
    const uri = `${this._baseUri}/${castMemberId}/${characterId}/addlink`;

    return this.doPost(null, uri);
  }

  public removeLink(castMemberId: number, characterId: number): Promise<any> {
    const uri = `${this._baseUri}/${castMemberId}/${characterId}/removelink`;

    return this.doPost(null, uri);
  }
}
