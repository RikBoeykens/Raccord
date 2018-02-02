import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DayNightHttpService } from '../../service/day-night-http.service';
import { DayNightSummary } from '../../model/day-night-summary.model';
import { DayNight } from '../../model/day-night.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../shared/helpers/html-class.helpers';

@Component({
    templateUrl: 'day-night-list.component.html',
})
export class DayNightListComponent implements OnInit {

    dayNights: DayNightSummary[] = [];
    project: ProjectSummary;

    constructor(
        private _dayNightHttpService: DayNightHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { dayNights: DayNightSummary[], project: ProjectSummary }) => {
            this.dayNights = data.dayNights;
            this.project = data.project;
        });
    }
}