import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseHttpService } from '../../../../../shared/service/base-http.service';
import { AppSettings } from '../../../../../app.settings';
import { CrewDepartment } from '../../../../../shared/children/crew';

@Injectable()
export class AdminCrewDepartmentHttpService extends BaseHttpService {

  constructor(
    protected _http: HttpClient,
  ) {
    super(_http);
    this._baseUri = `${AppSettings.API_ADMIN_ENDPOINT}/crewdepartments`;
  }

  public getAll(crewUnitId): Promise<CrewDepartment[] | void> {

    const uri = `${this._baseUri}/${crewUnitId}/unit`;

    return this.doGetArray(uri);
  }
}
