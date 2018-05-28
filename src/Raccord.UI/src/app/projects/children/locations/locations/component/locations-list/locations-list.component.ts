import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LocationHttpService } from '../../service/location-http.service';
import { LocationSummary } from '../../../';
import { Location } from '../../../';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { LatLng } from '../../../../../../shared/index';
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';
import { MapsHelpers } from '../../../../../../shared/helpers/maps.helpers';

@Component({
    templateUrl: 'locations-list.component.html',
})
export class LocationsListComponent implements OnInit {

    locations: LocationSummary[] = [];
    project: ProjectSummary;
    markerLocations: LocationSummary[] = [];
    bounds: any;

    constructor(
        private _locationHttpService: LocationHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { locations: LocationSummary[], project: ProjectSummary }) => {
            this.locations = data.locations;
            this.setBounds();
            this.project = data.project;
        });
    }

    getLocations(){
        this._loadingWrapperService.Load(
            this._locationHttpService.getAll(this.project.id),
            (data) => this.locations = data
        );
    }

    public setBounds() {
        this.markerLocations = this.locations.filter(l=> l.latLng.hasLatLng);
        if(this.markerLocations.length){
            this.bounds = MapsHelpers.getBounds(this.markerLocations.map((location)=> location.latLng));
        }
    }
}