import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Slate } from '../../model/slate.model';
import { SlateSummary } from '../../model/slate-summary.model';
import { SlateHttpService } from '../../service/slate-http.service';
import { ProjectSummary } from '../../../../../index';
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';

@Component({
    templateUrl: 'slates-list.component.html',
})
export class SlatesListComponent implements OnInit {

    public slates: SlateSummary[];
    public project: ProjectSummary;

    constructor(
        private _slateHttpService: SlateHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: { slates: SlateSummary[], project: ProjectSummary }) => {
            this.slates = data.slates;
            this.project = data.project;
        });
    }

    public getSlates(){
        this._loadingWrapperService.Load(
            this._slateHttpService.getAll(this.project.id),
            (data) => this.slates = data
        );
    }

    public addSlate() {
        let newSlate = new Slate();
        newSlate.projectID = this.project.id;

        this._loadingWrapperService.Load(
            this._slateHttpService.post(newSlate),
            (data) => this._router.navigate(['projects', this.project.id, 'slates', data])
        );
    }

    public remove(slate: SlateSummary) {

        if (this._dialogService.confirm(`Are you sure you want to remove slate ${slate.number}?`)) {
            this._loadingWrapperService.Load(
                this._slateHttpService.delete(slate.id),
                () => {
                    this._dialogService.success('The slate was successfully removed');
                    this.getSlates();
                }
            );
        }
    }
}
