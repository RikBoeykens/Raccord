import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LocationSetHttpService } from '../../service/location-set-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { FullLocationSet } from '../../model/full-location-set.model';
import { LocationSet } from '../../model/location-set.model';
import { ProjectSummary } from '../../../../../model/project-summary.model';

@Component({
    templateUrl: 'location-set-landing.component.html',
})
export class LocationSetLandingComponent {

    locationSet: FullLocationSet;
    viewLocationSet: LocationSet;
    project: ProjectSummary;

    constructor(
        private _locationHttpService: LocationSetHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { locationSet: FullLocationSet, project: ProjectSummary }) => {
            this.locationSet = data.locationSet;
            this.viewLocationSet = new LocationSet({
                id: data.locationSet.id, 
                name: data.locationSet.name,
                description: data.locationSet.description,
                latLng: data.locationSet.latLng,
                locationId: data.locationSet.location.id,
                scriptLocationId: data.locationSet.scriptLocation.id
            });
            this.project = data.project;
        });
    }

    getLocationSet(){
        let loadingId = this._loadingService.startLoading();

        this._locationHttpService.get(this.locationSet.id).then(data => {
            this.locationSet = data;
            this.viewLocationSet = new LocationSet({
                id: data.id, 
                name: data.name,
                description: data.description,
                latLng: data.latLng,
                locationId: data.location.id,
                scriptLocationId: data.scriptLocation.id
            });
            this._loadingService.endLoading(loadingId);
        });
    }

    updateLocationSet(){
        let loadingId = this._loadingService.startLoading();

        this._locationHttpService.post(this.viewLocationSet).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getLocationSet();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}