import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum }
    from '../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { CallsheetCrewUnit } from '../../model/callsheet-crew-unit.model';
import { ShootingDayCrewUnit } from '../../../shooting-days/model/shooting-day-crew-unit.model';
import { Callsheet } from '../..';
import { CallsheetHttpService } from '../../service/callsheet-http.service';
import { ShootingDay, ChooseShootingDayCrewUnitDialogComponent } from '../../../shooting-days';
import { ShootingDayHttpService } from '../../../shooting-days/service/shooting-day-http.service';
import { LoadingWrapperService } from '../../../../../shared';
import { MdDialog } from '@angular/material';

@Component({
    templateUrl: 'callsheets-list.component.html',
})
export class CallsheetsListComponent implements OnInit {

    public project: ProjectSummary;
    public callsheets: CallsheetCrewUnit[] = [];

    constructor(
        private _callsheetHttpService: CallsheetHttpService,
        private _shootingDayHttpService: ShootingDayHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _route: ActivatedRoute,
        private _router: Router,
        private _dialog: MdDialog
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            project: ProjectSummary,
            callsheets: CallsheetCrewUnit[]
        }) => {
            this.project = data.project;
            this.callsheets = data.callsheets;
        });
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canEditGeneral
        );
    }

    public showAddCallsheet() {
      this._loadingWrapperService.Load(
          this._shootingDayHttpService.getAvailableForCallsheet(this.project.id),
          (data: ShootingDayCrewUnit[]) => {
              let shootingDayDialog = this._dialog.open(
                  ChooseShootingDayCrewUnitDialogComponent, {data:
                  {
                      shootingDays: data
                  }});
              shootingDayDialog.afterClosed().subscribe(
                  (returnedShootingDay: ShootingDayCrewUnit) => {
                    if (returnedShootingDay) {
                        this.addCallsheet(returnedShootingDay);
                    }
              });
          }
      );
    }

    private addCallsheet(shootingDay: ShootingDayCrewUnit) {
        let callsheet = new Callsheet();
        callsheet.shootingDay = new ShootingDay();
        callsheet.shootingDay.id = shootingDay.id;
        callsheet.crewUnitID = shootingDay.crewUnit.id;

        this._loadingWrapperService.Load(
            this._callsheetHttpService.post(callsheet),
            (data) => {
                this._router.navigate([
                    'projects',
                    this.project.id,
                    'callsheets',
                    data,
                    'wizard',
                    1
                ]);
            }
        );
    }
}
