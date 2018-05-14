import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MdDialog } from '@angular/material';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { FullCrewDepartment } from '../../departments/model/full-crew-department.model';
import { EditCrewMemberDialog } from '../../index';
import { CrewDepartmentHttpService } from '../../departments/service/crew-department-http.service';
import { CrewMemberHttpService } from '../../crew-members/service/crew-member-http.service';
import { CrewMember } from '../../crew-members/model/crew-member.model';
import { CrewDepartment } from '../../departments/model/crew-department.model';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from
    '../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { CrewUnitSummary } from '../../crew-units/model/crew-unit-summary.model';
import { CrewUnitNavEnum } from '../../crew-units/enum/crew-unit-nav.enum';

@Component({
    templateUrl: 'crew-landing.component.html',
})
export class CrewLandingComponent implements OnInit {

    public departments: FullCrewDepartment[];
    public project: ProjectSummary;
    public crewUnit: CrewUnitSummary;

    constructor(
        private _crewDepartmentHttpService: CrewDepartmentHttpService,
        private _crewMemberHttpService: CrewMemberHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private _dialog: MdDialog
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data:
            {
                departments: FullCrewDepartment[],
                project: ProjectSummary,
                crewUnit: CrewUnitSummary
            }) => {
            this.departments = data.departments;
            this.project = data.project;
            this.crewUnit = data.crewUnit;
        });
    }

    public getDepartments() {
        let loadingId = this._loadingService.startLoading();
        this._crewDepartmentHttpService.getAll(this.project.id).then((data) => {
            this.departments = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    public addCrewMember(departmentId: number) {
        let crewMember = new CrewMember();
        crewMember.department = new CrewDepartment();
        crewMember.department.id = departmentId;
        this.showCrewMemberDialog(crewMember);
    }

    public editCrewMember(crewMember: CrewMember) {
        this.showCrewMemberDialog(crewMember);
    }

    public removeCrewMember(crewMember: CrewMember) {
        if (this._dialogService.confirm(
            // tslint:disable-next-line:max-line-length
            `Are you sure you want to remove character ${crewMember.firstName} ${crewMember.lastName}?`
        )) {
            let loadingId = this._loadingService.startLoading();
            this._crewMemberHttpService.delete(crewMember.id).then((data) => {
                if (typeof(data) === 'string') {
                    this._dialogService.error(data);
                }else {
                    this.getDepartments();
                }
            }).catch()
            .then(() =>
                this._loadingService.endLoading(loadingId)
            );
        }
    }

    public getFullName(crewMember: CrewMember) {
        return `${crewMember.firstName} ${crewMember.lastName}`;
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canEditGeneral
        );
    }

    public getUnitListNavType() {
        return CrewUnitNavEnum.unitLists;
    }

    private showCrewMemberDialog(crewMember: CrewMember) {
        let crewMemberDialog = this._dialog.open(EditCrewMemberDialog, {data:
            {
                crewMember,
                availableDepartments: this.getAvailableDepartments()
            }});
        crewMemberDialog.afterClosed().subscribe((returnedCrewMember: CrewMember) => {
            if (returnedCrewMember) {
                this.postCrewMember(returnedCrewMember);
            }
        });
    }

    private postCrewMember(crewMember: CrewMember) {
        let loadingId = this._loadingService.startLoading();
        this._crewMemberHttpService.post(crewMember).then((data) => {
            if (typeof(data) === 'string') {
                this._dialogService.error(data);
            }else {
                this.getDepartments();
            }
        }).catch()
        .then(() =>
            this._loadingService.endLoading(loadingId)
        );
    }

    private getAvailableDepartments() {
        return this.departments.map((crewDepartment) => new CrewDepartment(crewDepartment));
    }
}
