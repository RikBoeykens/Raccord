import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FullCastMember } from '../model/full-cast-member.model';
import { CastMemberSummary, CastMember } from '../../../../../../shared/children/cast';
import { BaseProjectHttpService } from '../../../../../shared/service/base-project-http.service';

@Injectable()
export class CastMemberHttpService extends BaseProjectHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http, 'castmembers');
    }

    public getAll(projectId): Promise<CastMemberSummary[] | void> {

        const uri = `${this.getUri(projectId)}/project`;

        return this.doGetArray(uri);
    }

    public get(authProjectId: number, id: number): Promise<FullCastMember | void> {

        const uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(authProjectId: number, id: number): Promise<CastMemberSummary | void> {

        const uri = `${this.getUri(authProjectId)}/${id}/summary`;

        return this.doGet(uri);
    }

    public post(authProjectId: number, take: CastMember): Promise<number> {
        const uri = this.getUri(authProjectId);

        return this.doPost(take, uri);
    }

    public delete(authProjectId: number, id: number): Promise<any> {
        const uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doDelete(uri);
    }

    public addLink(authProjectId: number, castMemberId: number, characterId: number): Promise<any> {
        const uri = `${this.getUri(authProjectId)}/${castMemberId}/${characterId}/addlink`;

        return this.doPost(null, uri);
    }

    public removeLink(
        authProjectId: number,
        castMemberId: number,
        characterId: number
    ): Promise<any> {
        const uri = `${this.getUri(authProjectId)}/${castMemberId}/${characterId}/removelink`;

        return this.doPost(null, uri);
    }
}
