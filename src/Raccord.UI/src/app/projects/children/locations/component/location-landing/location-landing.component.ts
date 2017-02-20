import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LocationHttpService } from '../../service/location-http.service';
import { FullLocation } from '../../model/full-location.model';
import { ProjectSummary } from '../../../../model/project-summary.model';

@Component({
    templateUrl: 'location-landing.component.html',
})
export class LocationLandingComponent {

    location: FullLocation;
    project: ProjectSummary;

    constructor(
        private _locationHttpService: LocationHttpService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { location: FullLocation, project: ProjectSummary }) => {
            this.location = data.location;
            this.project = data.project;
        });
    }
}