import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { AppSettings } from '../../../app.settings';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { CreateUserCrewMember } from '../model/create-user-crew-member.model';

@Injectable()
export class AdminProjectUserCrewHttpService extends BaseHttpService {

    constructor(protected _http: Http) {
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/projectusercrew`;
    }

    public post(createInfo: CreateUserCrewMember): Promise<any> {
        let uri = this._baseUri;

        return this.doPost(createInfo, uri);
    }

    public addLink(projectUserId: number, crewMemberId: number): Promise<any> {
        let uri = `${this._baseUri}/${projectUserId}/${crewMemberId}/addlink`;

        return this.doPost(null, uri);
    }

    public removeLink(projectUserId: number, crewMemberId: number): Promise<any> {
        let uri = `${this._baseUri}/${projectUserId}/${crewMemberId}/removelink`;

        return this.doPost(null, uri);
    }
}
