import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BreakdownType } from '../../model/breakdown-type.model';
import { BreakdownTypeSummary } from '../../model/breakdown-type-summary.model';
import { BreakdownTypeHttpService } from '../../service/breakdown-type-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';

@Component({
    templateUrl: 'breakdown-type-settings.component.html',
})
export class BreakdownTypeSettingsComponent extends OnInit {

    breakdownTypes: BreakdownTypeSummary[] = [];
    project: ProjectSummary;
    showAddType: boolean = true;

    viewNewBreakdownType: BreakdownType;
    newBreakdownType: BreakdownType;

    viewEditBreakdownType: BreakdownType;
    editBreakdownType: BreakdownType;

    constructor(
        private _breakdownTypeHttpService: BreakdownTypeHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
        super();
        this.viewNewBreakdownType = new BreakdownType();
    }

    ngOnInit() {
        this._route.data.subscribe((data: { breakdownTypes: BreakdownTypeSummary[], project: ProjectSummary }) => {
            this.breakdownTypes = data.breakdownTypes;
            this.project = data.project;
            this.resetNewBreakdownType();
        });
    }

    resetNewBreakdownType(){
        this.viewNewBreakdownType = new BreakdownType();
        this.viewNewBreakdownType.projectId = this.project.id;
        this.newBreakdownType = null;
    }

    getBreakdownTypes(){
        
        let loadingId = this._loadingService.startLoading();

        this._breakdownTypeHttpService.getAll(this.project.id).then(data => {
            this.breakdownTypes = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    addBreakdownType(){
        let loadingId = this._loadingService.startLoading();

        this.newBreakdownType = this.viewNewBreakdownType;

        this._breakdownTypeHttpService.post(this.newBreakdownType).then(data=>{
            if(typeof(data)=='string'){
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