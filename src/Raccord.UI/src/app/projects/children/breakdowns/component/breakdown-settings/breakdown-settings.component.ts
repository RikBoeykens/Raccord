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
import { MdDialog } from '@angular/material';
import { EditBreakdownTypeDialogComponent } from '../../children/breakdown-types/component/edit-breakdown-type-dialog/edit-breakdown-type-dialog.component';

@Component({
    templateUrl: 'breakdown-settings.component.html',
})
export class BreakdownSettingsComponent implements OnInit {

    public breakdown: FullBreakdown;
    public editBreakdown: Breakdown;
    public project: ProjectSummary;
    public showAddType: boolean = true;

    constructor(
        private _breakdownHttpService: BreakdownHttpService,
        private _breakdownTypeHttpService: BreakdownTypeHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private _dialog: MdDialog
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            breakdown: FullBreakdown,
            project: ProjectSummary
        }) => {
            this.breakdown = data.breakdown;
            this.editBreakdown = new Breakdown(data.breakdown);
            this.project = data.project;
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

    public getNewBreakdownType(): BreakdownType {
        let newBreakdownType = new BreakdownType();
        newBreakdownType.breakdownID = this.breakdown.id;
        return newBreakdownType;
    }

    public getBreakdownTypes() {
        let loadingId = this._loadingService.startLoading();

        this._breakdownTypeHttpService.getAllForBreakdown(this.breakdown.id).then(data => {
            this.breakdown.types = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    public showAddBreakdownType() {
        let editBreakdownTypeDialog = this._dialog.open(EditBreakdownTypeDialogComponent, {
            data: this.getNewBreakdownType()
        });
        editBreakdownTypeDialog.afterClosed().subscribe((breakdownType: BreakdownType) => {
            if (breakdownType) {
                this.postBreakdownType(breakdownType);
            }
        });
    }

    public showEditBreakdownType(breakdownType: BreakdownTypeSummary) {
        let editBreakdownTypeDialog = this._dialog.open(EditBreakdownTypeDialogComponent, {
            data: new BreakdownType(breakdownType)
        });
        editBreakdownTypeDialog.afterClosed().subscribe((updateBreakdownType: BreakdownType) => {
            if (updateBreakdownType) {
                this.postBreakdownType(updateBreakdownType);
            }
        });
    }

    public postBreakdownType(breakdownType: BreakdownType) {
        this._loadingWrapperService.Load(
            this._breakdownTypeHttpService.post(breakdownType),
            () => this.getBreakdownTypes()
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
}
