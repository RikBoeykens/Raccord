import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../../../app.settings';
import { BaseHttpService } from '../../../shared/service/base-http.service';
import { LinkedProjectUserUser } from '../../project-users/model/linked-project-user-user.model';
import { ProjectUserCrewUnit }
    from '../../../projects/children/crew/crew-units/model/project-user-crew-unit.model';

@Injectable()
export class AdminCrewUnitMemberHttpService extends BaseHttpService {

    constructor(
        protected _http: HttpClient,
    ) {
        super(_http);
        this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/crewunitmembers`;
    }

    public getCrewUnits(sceneId): Promise<ProjectUserCrewUnit[] | void> {

        let uri = `${this._baseUri}/${sceneId}/crewunits`;

        return this.doGetArray(uri);
    }

    public getProjectUsers(crewUnitId): Promise<LinkedProjectUserUser[] | void> {

        let uri = `${this._baseUri}/${crewUnitId}/projectusers`;

        return this.doGetArray(uri);
    }

    public addLink(projectUserId: number, crewUnitId: number): Promise<any> {
        let uri = `${this._baseUri}/${projectUserId}/${crewUnitId}/addlink`;

        return this.doPost(null, uri);
    }

    public removeLink(linkID: number): Promise<any>{
        let uri = `${this._baseUri}/${linkID}/removelink`;

        return this.doPost(null, uri);
    }
}
