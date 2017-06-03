import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BreakdownItemHttpService } from '../../service/breakdown-item-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { FullBreakdownItem } from '../../model/full-breakdown-item.model';
import { BreakdownItem } from '../../model/breakdown-item.model';
import { ProjectSummary } from '../../../../../model/project-summary.model';

@Component({
    templateUrl: 'breakdown-item-landing.component.html',
})
export class BreakdownItemLandingComponent {

    breakdownItem: FullBreakdownItem;
    viewBreakdownItem: BreakdownItem;
    project: ProjectSummary;

    constructor(
        private _breakdownItemHttpService: BreakdownItemHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { breakdownItem: FullBreakdownItem, project: ProjectSummary }) => {
            this.breakdownItem = data.breakdownItem;
            this.viewBreakdownItem = new BreakdownItem(data.breakdownItem);
            this.project = data.project;
        });
    }

    getBreakdownItem(){
        let loadingId = this._loadingService.startLoading();

        this._breakdownItemHttpService.get(this.breakdownItem.id).then(data => {
            this.breakdownItem = data;
            this.viewBreakdownItem = new BreakdownItem(data);
            this._loadingService.endLoading(loadingId);
        });
    }

    updateBreakdownItem(){
        let loadingId = this._loadingService.startLoading();

        this._breakdownItemHttpService.post(this.viewBreakdownItem).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getBreakdownItem();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}