import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IntExtHttpService } from '../../service/int-ext-http.service';
import { FullIntExt } from '../../model/full-int-ext.model';
import { ProjectSummary } from '../../../../model/project-summary.model';

@Component({
    templateUrl: 'int-ext-landing.component.html',
})
export class IntExtLandingComponent {

    intExt: FullIntExt;
    project: ProjectSummary;

    constructor(
        private _intExtHttpService: IntExtHttpService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { intExt: FullIntExt, project: ProjectSummary }) => {
            this.intExt = data.intExt;
            this.project = data.project;
        });
    }
}