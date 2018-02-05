import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { CallsheetSummary } from "../../";
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from '../../../../../shared/children/users/project-roles/enums/project-permission.enum';

@Component({
    templateUrl: 'callsheets-list.component.html',
})
export class CallsheetsListComponent implements OnInit {

    project: ProjectSummary;
    callsheets: CallsheetSummary[] = [];

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, callsheets: CallsheetSummary[] }) => {
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
}