import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MdDialog } from '@angular/material';
import { ProjectSummary, EditCrewUnitDialogComponent } from '../../../../projects';
import { CrewUnitHttpService }
  from '../../../../projects/children/crew/crew-units/service/crew-unit-http.service';
import { CrewUnitSummary }
  from '../../../../projects/children/crew/crew-units/model/crew-unit-summary.model';
import { LoadingWrapperService } from '../../../../shared/service/loading-wrapper.service';
import { CrewUnit } from '../../../../projects/children/crew/crew-units/model/crew-unit.model';

@Component({
    templateUrl: 'admin-crew-units-list.component.html',
})
export class AdminCrewUnitsListComponent implements OnInit {

  public project: ProjectSummary;
  public crewUnits: CrewUnitSummary[] = [];

  constructor(
    private _crewUnitService: CrewUnitHttpService,
    private _loadingWrapperService: LoadingWrapperService,
    private _route: ActivatedRoute,
    private _router: Router,
    private _dialog: MdDialog
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
    let newCrewUnit = new CrewUnit();
    newCrewUnit.projectID = this.project.id;
    this.showCrewUnitDialog(newCrewUnit);
  }

  public editCrewUnit(crewUnit: CrewUnitSummary) {
    this.showCrewUnitDialog(crewUnit);
  }

  public removeCrewUnit(crewUnit: CrewUnitSummary) {
    this._loadingWrapperService.Load(
      this._crewUnitService.delete(this.project.id, crewUnit.id),
      () => this.getCrewUnits()
    );
  }

  private getCrewUnits() {
    this._loadingWrapperService.Load(
      this._crewUnitService.getAll(this.project.id),
      (data) => this.crewUnits = data
    );
  }

  private showCrewUnitDialog(crewUnit: CrewUnit) {
      let crewUnitDialog = this._dialog.open(EditCrewUnitDialogComponent, {data:
          {
              crewUnit,
          }});
      crewUnitDialog.afterClosed().subscribe((returnedCrewUnit: CrewUnit) => {
          if (returnedCrewUnit) {
              this.postCrewMember(returnedCrewUnit);
          }
      });
  }

  private postCrewMember(crewUnit: CrewUnit) {
    this._loadingWrapperService.Load(
      this._crewUnitService.post(this.project.id, crewUnit),
      () => this.getCrewUnits()
    );
  }
}
