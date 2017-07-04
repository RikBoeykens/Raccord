import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LocationHttpService } from '../../service/location-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { FullLocation } from '../../model/full-location.model';
import { Location } from '../../model/location.model';
import { ProjectSummary } from '../../../../../model/project-summary.model';

@Component({
    templateUrl: 'location-landing.component.html',
})
export class LocationLandingComponent {

    location: FullLocation;
    viewLocation: Location;
    project: ProjectSummary;

    constructor(
        private _locationHttpService: LocationHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { location: FullLocation, project: ProjectSummary }) => {
            this.location = data.location;
            this.viewLocation = new Location(data.location);
            this.project = data.project;
        });
    }

    getLocation(){
        let loadingId = this._loadingService.startLoading();

        this._locationHttpService.get(this.location.id).then(data => {
            this.location = data;
            this.viewLocation = new Location(data);
            this._loadingService.endLoading(loadingId);
        });
    }

    updateLocation(){
        let loadingId = this._loadingService.startLoading();

        this._locationHttpService.post(this.viewLocation).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getLocation();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}