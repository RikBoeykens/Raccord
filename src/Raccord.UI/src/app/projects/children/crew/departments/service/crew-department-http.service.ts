import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { CrewDepartment } from '../model/crew-department.model';

@Injectable()
export class CrewDepartmentHttpService extends BaseHttpService {

    constructor(protected _http: Http) {
        super(_http);
        this._baseUri = `${AppSettings.API_ENDPOINT}/crewdepartments`;
    }

    public getAll(projectId): Promise<CrewDepartment[]> {

        const uri = `${this._baseUri}/${projectId}/project`;

        return this.doGetArray(uri);
    }
}