import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { FullBreakdown } from '../../model/full-breakdown.model';
import { BreakdownType } from '../../children/breakdown-types/model/breakdown-type.model';
import { BreakdownTypeHttpService } from
    '../../children/breakdown-types/service/breakdown-type-http.service';
import { BreakdownTypeSummary } from '../../children/breakdown-types/model/breakdown-type-summary.model';
import { BreakdownHttpService } from '../../service/breakdown-http.service';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { Breakdown } from '../../model/breakdown.model';

@Component({
    templateUrl: 'breakdown-settings.component.html',
})
export class BreakdownSettingsComponent implements OnInit {

    public breakdown: FullBreakdown;
    public editBreakdown: Breakdown;
    public project: ProjectSummary;
    public showAddType: boolean = true;

    public viewNewBreakdownType: BreakdownType;
    public newBreakdownType: BreakdownType;

    public viewEditBreakdownType: BreakdownType;
    public editBreakdownType: BreakdownType;

    constructor(
        private _breakdownHttpService: BreakdownHttpService,
        private _breakdownTypeHttpService: BreakdownTypeHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
        this.viewNewBreakdownType = new BreakdownType();
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            breakdown: FullBreakdown,
            project: ProjectSummary
        }) => {
            this.breakdown = data.breakdown;
            this.editBreakdown = new Breakdown(data.breakdown);
            this.project = data.project;
            this.resetNewBreakdownType();
        });
    }

    public getBreakdown() {
        this._loadingWrapperService.Load(
            this._breakdownHttpService.get(this.project.id, this.breakdown.id),
            (data) => {
                this.breakdown = data;
                this.editBreakdown = new Breakdown(data);
            }
        );
    }

    public updateBreakdown() {
        this._loadingWrapperService.Load(
            this._breakdownHttpService.post(this.project.id, this.editBreakdown),
            () => {
                this.getBreakdown();
            }
        );
    }

    public resetNewBreakdownType() {
        this.viewNewBreakdownType = new BreakdownType();
        this.viewNewBreakdownType.breakdownID = this.breakdown.id;
        this.newBreakdownType = null;
    }

    public getBreakdownTypes() {
        let loadingId = this._loadingService.startLoading();

        this._breakdownTypeHttpService.getAllForBreakdown(this.breakdown.id).then(data => {
            this.breakdown.types = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    public addBreakdownType(){
        let loadingId = this._loadingService.startLoading();

        this.newBreakdownType = this.viewNewBreakdownType;

        this._breakdownTypeHttpService.post(this.newBreakdownType).then(data=>{
            if(typeof(data) === 'string'){
                this._dialogService.error(data);
            }else{
                this.getBreakdownTypes();
                this.resetNewBreakdownType();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    remove(breakdownType: BreakdownTypeSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove type ${breakdownType.name}?`)){

            let loadingId = this._loadingService.startLoading();

            this._breakdownTypeHttpService.delete(breakdownType.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                }else{
                    this._dialogService.success('The type was successfully removed');
                    this.getBreakdownTypes();
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }

    }

    toggleEditBreakdownType(breakdownType: BreakdownTypeSummary){
        this.viewEditBreakdownType = new BreakdownType(breakdownType);
        this.showAddType = false;
    }

    updateBreakdownType(){
        let loadingId = this._loadingService.startLoading();

        this.editBreakdownType = this.viewEditBreakdownType;

        this._breakdownTypeHttpService.post(this.editBreakdownType).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getBreakdownTypes();
                this.resetNewBreakdownType();
                this.showAddType = true;
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

}