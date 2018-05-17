import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../app.settings';
import { CastMember } from '../model/cast-member.model';
import { CastMemberSummary } from '../model/cast-member-summary.model';
import { FullCastMember } from '../model/full-cast-member.model';
import { AuthService } from '../../../../security/service/auth.service';

@Injectable()
export class CastMemberHttpService extends BaseHttpService {

    constructor(
        protected _http: Http,
        protected _authService: AuthService
    ) {
        super(_http, _authService);
        this._baseUri = `${AppSettings.API_ENDPOINT}/castmembers`;
    }

    public getAll(projectId): Promise<CastMemberSummary[]> {

        let uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }

    public get(id: number): Promise<FullCastMember> {

        let uri = `${this._baseUri}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(id: Number): Promise<CastMemberSummary> {

        let uri = `${this._baseUri}/${id}/summary`;

        return this.doGet(uri);
    }

    public post(take: CastMember): Promise<number> {
        let uri = this._baseUri;

        return this.doPost(take, uri);
    }

    public delete(id: Number): Promise<any> {
        let uri = `${this._baseUri}/${id}`;

        return this.doDelete(uri);
    }

    public addLink(castMemberId: number, characterId: number): Promise<any> {
        let uri = `${this._baseUri}/${castMemberId}/${characterId}/addlink`;

        return this.doPost(null, uri);
    }

    public removeLink(castMemberId: number, characterId: number): Promise<any> {
        let uri = `${this._baseUri}/${castMemberId}/${characterId}/removelink`;

        return this.doPost(null, uri);
    }
}
