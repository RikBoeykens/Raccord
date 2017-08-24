import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { FullShootingDay } from "../../model/full-shooting-day.model";
import { ShootingDayHttpService } from "../../service/shooting-day-http.service";

@Component({
    templateUrl: 'shooting-day-report-landing.component.html',
})
export class ShootingDayReportLandingComponent {

    shootingDay: FullShootingDay;
    project: ProjectSummary;

    constructor(
        private _shootingDayHttpService: ShootingDayHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { shootingDay: FullShootingDay, project: ProjectSummary }) => {
            this.shootingDay = data.shootingDay;
            this.project = data.project;
        });
    }

    getShootingDay(){
        let loadingId = this._loadingService.startLoading();

        this._shootingDayHttpService.get(this.shootingDay.id).then(data => {
            this.shootingDay = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    updateScriptLocation(){
        let loadingId = this._loadingService.startLoading();

        this._shootingDayHttpService.post(this.shootingDay).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getShootingDay();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}