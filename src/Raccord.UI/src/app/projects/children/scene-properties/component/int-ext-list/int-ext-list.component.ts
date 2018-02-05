import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IntExtHttpService } from '../../service/int-ext-http.service';
import { IntExtSummary } from '../../model/int-ext-summary.model';
import { IntExt } from '../../model/int-ext.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../shared/helpers/html-class.helpers';

@Component({
    templateUrl: 'int-ext-list.component.html',
})
export class IntExtListComponent implements OnInit {

    intExts: IntExtSummary[] = [];
    project: ProjectSummary;

    constructor(
        private _intExtHttpService: IntExtHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { intExts: IntExtSummary[], project: ProjectSummary }) => {
            this.intExts = data.intExts;
            this.project = data.project;
        });
    }
}
