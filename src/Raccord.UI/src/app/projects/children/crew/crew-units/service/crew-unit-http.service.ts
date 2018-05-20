import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../../../app.settings';
import { BaseProjectHttpService } from '../../../../shared/service/base-project-http.service';
import { CrewUnitSummary } from '../model/crew-unit-summary.model';
import { FullCrewUnit } from '../model/full-crew-unit.model';
import { CrewUnit } from '../model/crew-unit.model';

@Injectable()
export class CrewUnitHttpService extends BaseProjectHttpService {

    constructor(protected _http: HttpClient) {
        super(_http, 'crewunits');
    }

    public getAll(authProjectId: number): Promise<CrewUnitSummary[] | void> {

        let uri = `${this.getUri(authProjectId)}/project`;

        return this.doGetArray(uri);
    }

    public getAllForUser(authProjectId: number): Promise<CrewUnitSummary[] | void> {

        let uri = `${this.getUri(authProjectId)}/user`;

        return this.doGetArray(uri);
    }

    public get(authProjectId: number, id: number): Promise<FullCrewUnit | void> {

        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doGet(uri);
    }

    public getSummary(authProjectId: number, id: Number): Promise<CrewUnitSummary | void> {

        let uri = `${this.getUri(authProjectId)}/${id}/summary`;

        return this.doGet(uri);
    }

    public post(authProjectId: number, breakdown: CrewUnit): Promise<number> {
        let uri = this.getUri(authProjectId);

        return this.doPost(breakdown, uri);
    }

    public delete(authProjectId: number, id: Number): Promise<any> {
        let uri = `${this.getUri(authProjectId)}/${id}`;

        return this.doDelete(uri);
    }
}
