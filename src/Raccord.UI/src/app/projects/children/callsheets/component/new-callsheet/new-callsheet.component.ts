import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { ShootingDay } from "../../../shooting-days"

@Component({
    templateUrl: 'new-callsheet.component.html',
})
export class NewCallsheetComponent implements OnInit {

    project: ProjectSummary;
    availableShootingDays: ShootingDay[] = [];
    selectedDayId: number;

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, availableDays: ShootingDay[] }) => {
            this.project = data.project;
            this.availableShootingDays = data.availableDays;
        });
    }

    addCallsheet(){
        console.log(this.selectedDayId);
    }
}