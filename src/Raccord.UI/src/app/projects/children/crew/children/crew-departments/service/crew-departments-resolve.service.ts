import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CrewDepartmentHttpService } from './crew-department-http.service';
import { FullCrewDepartment } from '../../../../../../shared/children/crew';
@Injectable()
export class CrewDepartmentsResolve implements Resolve<FullCrewDepartment[]> {

  constructor(
    private _crewDepartmentHttpService: CrewDepartmentHttpService
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const crewUnitId = route.params['crewUnitId'];
        return this._crewDepartmentHttpService.getAll(crewUnitId)
            .then((data: FullCrewDepartment[]) => data);
    }
}
