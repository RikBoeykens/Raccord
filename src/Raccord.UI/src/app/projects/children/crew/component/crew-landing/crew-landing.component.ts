import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { CrewDepartment } from '../../departments/model/crew-department.model';

@Component({
    templateUrl: 'crew-landing.component.html',
})
export class CrewLandingComponent implements OnInit {

    departments: CrewDepartment[];
    project: ProjectSummary;

    constructor(
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { departments: CrewDepartment[], project: ProjectSummary }) => {
            this.departments = data.departments;
            this.project = data.project;
        });
    }
}