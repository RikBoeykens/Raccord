import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import { ProjectLinkCrewUnit } from '../../../../../../shared/children/crew';
import { LinkedProjectUserUser } from '../../../../../../shared/children/users';

@Injectable()
export class AdminCrewUnitInvitationMemberHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/crewunitinvitationmembers`;
  }

  public getCrewUnits(projectUserId: number): Promise<ProjectLinkCrewUnit[] | void> {

    const uri = `${this._baseUri}/${projectUserId}/crewunits`;

    return this.doGetArray(uri);
  }

  public getProjectUsers(crewUnitId): Promise<LinkedProjectUserUser[] | void> {

    const uri = `${this._baseUri}/${crewUnitId}/projectusers`;

    return this.doGetArray(uri);
  }

  public addLink(projectUserId: number, crewUnitId: number): Promise<any> {
    const uri = `${this._baseUri}/${projectUserId}/${crewUnitId}/addlink`;

    return this.doPost(null, uri);
  }

  public removeLink(linkID: number): Promise<any> {
    const uri = `${this._baseUri}/${linkID}/removelink`;

    return this.doPost(null, uri);
  }
}
