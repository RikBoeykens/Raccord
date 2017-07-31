import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CallsheetHttpService } from "../../service/callsheet-http.service";
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { Callsheet } from "../../";
import { ShootingDay } from "../../../shooting-days"

@Component({
    templateUrl: 'new-callsheet.component.html',
})
export class NewCallsheetComponent implements OnInit {

    project: ProjectSummary;
    availableShootingDays: ShootingDay[] = [];
    selectedDayId: number;

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
        private _callsheetHttpService: CallsheetHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, availableDays: ShootingDay[] }) => {
            this.project = data.project;
            this.availableShootingDays = data.availableDays;
        });
    }

    addCallsheet(){
        let callsheet = new Callsheet();
        callsheet.shootingDay = new ShootingDay();
        callsheet.shootingDay.id = this.selectedDayId;
        callsheet.projectId = this.project.id;

        let loadingId = this._loadingService.startLoading();

        this._callsheetHttpService.post(callsheet).then(data=>{
            if(typeof(data)== 'string'){
                this._dialogService.error(data);
            }else{
                this._router.navigate(["projects", this.project.id, "callsheets", data, "wizard", 1]);
            }
        }).catch()
        .then(()=> this._loadingService.endLoading(loadingId));
    }
}