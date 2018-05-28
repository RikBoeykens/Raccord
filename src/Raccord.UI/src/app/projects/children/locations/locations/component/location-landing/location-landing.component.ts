import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LocationHttpService } from '../../service/location-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { FullLocation } from '../../model/full-location.model';
import { Location } from '../../model/location.model';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { AppSettings } from '../../../../../../app.settings';
import { LocationSetScriptLocation } from '../../../index';
import { MapsHelpers } from '../../../../../../shared/helpers/maps.helpers';
import { AccountHelpers } from '../../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from '../../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';

@Component({
    templateUrl: 'location-landing.component.html',
})
export class LocationLandingComponent {

    location: FullLocation;
    viewLocation: Location;
    project: ProjectSummary;
    zoom: number = AppSettings.MAP_DEFAULT_ZOOM;
    bounds: any;
    locationSetMarkers: LocationSetScriptLocation[] = [];

    constructor(
        private _locationHttpService: LocationHttpService,
        private _loadingWrapperService: LoadingWrapperService,
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
            this.setBounds();
            this.project = data.project;
        });
    }

    getLocation(){
        this._loadingWrapperService.Load(
            this._locationHttpService.get(this.location.id),
            (data) => {
                this.location = data;
                this.viewLocation = new Location(data);
            }
        );
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
    
    public setBounds(){
        if(this.location.latLng.hasLatLng){
            this.locationSetMarkers = this.location.sets.filter(set=> set.latLng.hasLatLng);
            let latLngs = this.locationSetMarkers.map(set=> set.latLng);
            latLngs.push(this.location.latLng);
            this.bounds = MapsHelpers.getBounds(latLngs);
        }
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canEditGeneral
        );
    }
}