import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseProjectHttpService } from '../../../../../shared/service/base-project-http.service';
import { CrewUnitSummary, CrewUnit } from '../../../../../../shared/children/crew';
import { FullCrewUnit } from '../../../../..';

@Injectable()
export class CrewUnitHttpService extends BaseProjectHttpService {

    constructor(protected _http: HttpClient) {
        super(_http, 'crewunits');
    }

    public getAll(authProjectId: number): Promise<CrewUnitSummary[] | void> {

      const uri = `${this.getUri(authProjectId)}/project`;

      return this.doGetArray(uri);
    }

    public getAllForUser(authProjectId: number): Promise<CrewUnitSummary[] | void> {

      const uri = `${this.getUri(authProjectId)}/user`;

      return this.doGetArray(uri);
    }

    public get(authProjectId: number, id: number): Promise<FullCrewUnit | void> {

      const uri = `${this.getUri(authProjectId)}/${id}`;

      return this.doGet(uri);
    }

    public getSummary(authProjectId: number, id: number): Promise<CrewUnitSummary | void> {

      const uri = `${this.getUri(authProjectId)}/${id}/summary`;

      return this.doGet(uri);
    }

    public post(authProjectId: number, crewUnit: CrewUnit): Promise<number> {
      const uri = this.getUri(authProjectId);

      return this.doPost(crewUnit, uri);
    }

    public delete(authProjectId: number, id: number): Promise<any> {
      const uri = `${this.getUri(authProjectId)}/${id}`;

      return this.doDelete(uri);
    }
}
