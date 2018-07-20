import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../../app.settings';
import { CreateCrewUnitMemberCrewMember } from '../../../../..';

@Injectable()
export class AdminCrewUnitMemberCrewMembersHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/crewunitmembercrewmembers`;
    }

    public post(createInfo: CreateCrewUnitMemberCrewMember): Promise<any> {
      const uri = this._baseUri;

      return this.doPost(createInfo, uri);
    }

    public addLink(crewUnitMemberId: number, crewMemberId: number): Promise<any> {
      const uri = `${this._baseUri}/${crewUnitMemberId}/${crewMemberId}/addlink`;

      return this.doPost(null, uri);
    }

    public removeLink(crewUnitMemberId: number, crewMemberId: number): Promise<any> {
      const uri = `${this._baseUri}/${crewUnitMemberId}/${crewMemberId}/removelink`;

      return this.doPost(null, uri);
    }
}
