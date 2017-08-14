import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { FullSlate } from "../../model/full-slate.model";
import { Slate } from "../../model/slate.model";
import { SlateHttpService } from "../../service/slate-http.service";
import { LoadingService } from "../../../../../../loading/service/loading.service";
import { DialogService } from "../../../../../../shared/service/dialog.service";

@Component({
    templateUrl: 'slate-landing.component.html',
})
export class SlateLandingComponent {

    slate: FullSlate;
    viewSlate: Slate;
    project: ProjectSummary;

    constructor(
        private _locationHttpService: SlateHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { slate: FullSlate, project: ProjectSummary }) => {
            this.slate = data.slate;
            this.viewSlate = new Slate(data.slate);
            this.project = data.project;
        });
    }

    getSlate(){
        let loadingId = this._loadingService.startLoading();

        this._locationHttpService.get(this.slate.id).then(data => {
            this.slate = data;
            this.viewSlate = new Slate(data);
            this._loadingService.endLoading(loadingId);
        });
    }

    updateSlate(){
        let loadingId = this._loadingService.startLoading();

        this._locationHttpService.post(this.viewSlate).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getSlate();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}