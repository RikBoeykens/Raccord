import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { ShootingDaySummary } from "../../model/shooting-day-summary.model";
import { TimespanHelpers } from "../../../../../shared/helpers/timespan.helpers";
import { ShootingDayHttpService } from "../../service/shooting-day-http.service";
import { MdDialog } from '@angular/material';
import { ChooseShootingDayDialog } from "../choose-shooting-day-dialog/choose-shooting-day-dialog.component";
import { LoadingService } from "../../../../../loading/service/loading.service";
import { DialogService } from "../../../../../shared/service/dialog.service";
import { ShootingDay } from "../../index";

@Component({
    templateUrl: 'shooting-day-reports-list.component.html',
})
export class ShootingDayReportsListComponent implements OnInit {

    project: ProjectSummary;
    shootingDays: ShootingDaySummary[] = [];
    availableDays: ShootingDay[] = [];

    constructor(
        private _shootingDayHttpService: ShootingDayHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private _dialog: MdDialog
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, shootingDays: ShootingDaySummary[], availableDays: ShootingDay[] }) => {
            this.project = data.project;
            this.shootingDays = data.shootingDays;
            this.availableDays = data.availableDays;
        });
    }

    createReport(){
        let shootingDayDialog = this._dialog.open(ChooseShootingDayDialog, {data: this.availableDays});
        shootingDayDialog.afterClosed().subscribe((shootingDay: ShootingDay)=> {
            if(shootingDay){
                let loadingId = this._loadingService.startLoading();
                
                    this._shootingDayHttpService.prepareCompletion(shootingDay.id).then(data=>{
                        if(typeof(data)=='string'){
                            this._dialogService.error(data);
                        }else{
                            this._router.navigate(["projects", this.project.id, "shootingdays", shootingDay.id]);
                        }
                    }).catch()
                    .then(()=>
                        this._loadingService.endLoading(loadingId)
                    );
            }
        });
    }

    getTotalCompletedScenes(){
        let count = 0;
        this.shootingDays.forEach((shootingDay: ShootingDaySummary)=>{ count += shootingDay.completedScenes});
        return count;
    }
    
    getTotalPageCount(){
        let count = 0;
        this.shootingDays.forEach((shootingDay: ShootingDaySummary)=>{ count += shootingDay.totalPageCount});
        return count;
    }
    
    getTotalTimings(){
        let count = 0;
        this.shootingDays.forEach((shootingDay: ShootingDaySummary)=>{ count += TimespanHelpers.getTimespanNumber(shootingDay.totalTimings)});
        return count;
    }
    
    getTotalSetups(){
        let count = 0;
        this.shootingDays.forEach((shootingDay: ShootingDaySummary)=>{ count += shootingDay.totalSetups});
        return count;
    }
    
    getTotalOvertime(){
        let count = 0;
        this.shootingDays.forEach((shootingDay: ShootingDaySummary)=>{ count += TimespanHelpers.getTimespanNumber(shootingDay.overTime)});
        return count;
    }
}