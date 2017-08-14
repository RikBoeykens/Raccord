import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Slate } from "../../model/slate.model";
import { SlateSummary } from "../../model/slate-summary.model";
import { SlateHttpService } from "../../service/slate-http.service";
import { LoadingService } from "../../../../../../loading/service/loading.service";
import { DialogService } from "../../../../../../shared/service/dialog.service";
import { ProjectSummary } from "../../../../../index";

@Component({
    templateUrl: 'slates-list.component.html',
})
export class SlatesListComponent implements OnInit {

    slates: SlateSummary[];
    project: ProjectSummary;

    constructor(
        private _slateHttpService: SlateHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { slates: SlateSummary[], project: ProjectSummary }) => {
            this.slates = data.slates;
            this.project = data.project;
        });
    }

    getSlates(){
        
        let loadingId = this._loadingService.startLoading();

        this._slateHttpService.getAll(this.project.id).then(data => {
            this.slates = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    addSlate(){
        let loadingId = this._loadingService.startLoading();

        let newSlate = new Slate();
        newSlate.projectID = this.project.id;

        this._slateHttpService.post(newSlate).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this._router.navigate(["projects", this.project.id, "slates", data]);
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    remove(slate: SlateSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove slate ${slate.number}?`)){

            let loadingId = this._loadingService.startLoading();

            this._slateHttpService.delete(slate.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                }else{
                    this._dialogService.success('The slate was successfully removed');
                    this.getSlates();
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }

    }
}