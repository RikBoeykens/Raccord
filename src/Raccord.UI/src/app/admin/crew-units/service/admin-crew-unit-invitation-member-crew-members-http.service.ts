import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../app.settings';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { CreateCrewUnitInvitationMemberCrewMember } from
    '../model/create-crew-unit-invitation-member-crew-member.model';

@Injectable()
export class AdminCrewUnitInvitationMemberCrewMembersHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/crewunitinvitationmembercrewmembers`;
    }

    public post(createInfo: CreateCrewUnitInvitationMemberCrewMember): Promise<any> {
        let uri = this._baseUri;

        return this.doPost(createInfo, uri);
    }

    public addLink(crewUnitInvitationMemberId: number, crewMemberId: number): Promise<any> {
        let uri = `${this._baseUri}/${crewUnitInvitationMemberId}/${crewMemberId}/addlink`;

        return this.doPost(null, uri);
    }

    public removeLink(crewUnitInvitationMemberId: number, crewMemberId: number): Promise<any> {
        let uri = `${this._baseUri}/${crewUnitInvitationMemberId}/${crewMemberId}/removelink`;

        return this.doPost(null, uri);
    }
}
