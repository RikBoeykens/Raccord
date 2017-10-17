import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CrewDepartment } from '../model/crew-department.model';
import { CrewDepartmentHttpService } from './crew-department-http.service';
@Injectable()
export class CrewDepartmentsResolve implements Resolve<CrewDepartment[]> {

  constructor(
    private _crewDepartmentHttpService: CrewDepartmentHttpService,
    private router: Router
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this._crewDepartmentHttpService.getAll(projectId).then((data) => {
            return data;
        });
    }
}
