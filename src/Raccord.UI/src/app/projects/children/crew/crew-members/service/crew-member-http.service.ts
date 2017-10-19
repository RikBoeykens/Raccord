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

    getAll(slateId): Promise<CrewMemberSummary[]> {

        var uri = `${this._baseUri}/${slateId}/slate`;

        return this.doGetArray(uri);
    }

    get(id: number): Promise<FullCrewMember>{

        var uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    getSummary(id: Number): Promise<CrewMemberSummary> {

        var uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    post(take: CrewMember): Promise<number> {
        var uri = this._baseUri;

        return this.doPost(take, uri);
    }

    delete(id: Number): Promise<any> {
        var uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }
}