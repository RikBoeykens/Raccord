import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { AccountHelpers } from '../../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from
  '../../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';
import { CrewUnitHttpService } from '../../service/crew-unit-http.service';
import { CrewUnit } from '../../model/crew-unit.model';
import { CrewUnitSummary } from '../../model/crew-unit-summary.model';

@Component({
    templateUrl: 'crew-units-list.component.html',
})
export class CrewUnitsListComponent implements OnInit {

  public project: ProjectSummary;
  public crewUnits: CrewUnitSummary[] = [];

  constructor(
    private _crewUnitService: CrewUnitHttpService,
    private _loadingWrapperService: LoadingWrapperService,
    private _route: ActivatedRoute,
    private _router: Router,
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: {
      project: ProjectSummary,
      crewUnits: CrewUnitSummary[]
    }) => {
      this.project = data.project;
      this.crewUnits = data.crewUnits;
    });
  }

  public addCrewUnit() {
    this._loadingWrapperService.Load(
      this._crewUnitService.post(
        this.project.id,
        new CrewUnit({
          id: 0,
          name: `New Unit`,
          description: '',
          projectID: this.project.id
        })
      ),
      () => this.getCrewUnits()
    );
  }

  public editCrewUnit(crewUnit: CrewUnitSummary) {
    console.log(crewUnit);
  }

  public removeCrewUnit(crewUnit: CrewUnitSummary) {
    this._loadingWrapperService.Load(
      this._crewUnitService.delete(this.project.id, crewUnit.id),
      () => this.getCrewUnits()
    );
  }

  public getCanEdit() {
    return AccountHelpers.hasProjectPermission(
      this.project.id,
      ProjectPermissionEnum.canEditGeneral
    );
  }

  private getCrewUnits() {
    this._loadingWrapperService.Load(
      this._crewUnitService.getAll(this.project.id),
      (data) => this.crewUnits = data
    );
    this._crewUnitService.getAll(this.project.id).then((data) => this.crewUnits = data);
  }
}
