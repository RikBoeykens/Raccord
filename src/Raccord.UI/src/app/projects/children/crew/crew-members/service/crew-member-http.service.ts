import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { CrewMember } from '../model/crew-member.model';
import { CrewMemberSummary } from '../model/crew-member-summary.model';
import { FullCrewMember } from '../model/full-crew-member.model';

@Injectable()
export class CrewMemberHttpService extends BaseHttpService {

    constructor(protected _http: Http) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/crewmembers`;
    }

    public getAll(departmentId): Promise<CrewMemberSummary[]> {

        let uri = `${this._baseUri}/${departmentId}/department`;

        return this.doGetArray(uri);
    }

    public get(id: number): Promise<FullCrewMember> {

        let uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(id: Number): Promise<CrewMemberSummary> {

        let uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    public post(take: CrewMember): Promise<number> {
        let uri = this._baseUri;

        return this.doPost(take, uri);
    }

    public delete(id: Number): Promise<any> {
        let uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}
