import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../app.settings';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { CreateUnitCrewMember } from '../model/create-unit-crew-member.model';

@Injectable()
export class AdminUnitCrewMembersHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/unitcrewmembers`;
    }

    public post(createInfo: CreateUnitCrewMember): Promise<any> {
        let uri = this._baseUri;

        return this.doPost(createInfo, uri);
    }

    public addLink(crewUnitMemberId: number, crewMemberId: number): Promise<any> {
        let uri = `${this._baseUri}/${crewUnitMemberId}/${crewMemberId}/addlink`;

        return this.doPost(null, uri);
    }

    public removeLink(crewUnitMemberId: number, crewMemberId: number): Promise<any> {
        let uri = `${this._baseUri}/${crewUnitMemberId}/${crewMemberId}/removelink`;

        return this.doPost(null, uri);
    }
}
