import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LocationSetHttpService } from '../../service/location-set-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { FullLocationSet } from '../../model/full-location-set.model';
import { LocationSet } from '../../model/location-set.model';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { AppSettings } from '../../../../../../app.settings';
import { MapsHelpers } from '../../../../../../shared/helpers/maps.helpers';
import { AccountHelpers } from '../../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from '../../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';

@Component({
    templateUrl: 'location-set-landing.component.html',
})
export class LocationSetLandingComponent {

    locationSet: FullLocationSet;
    viewLocationSet: LocationSet;
    project: ProjectSummary;
    bounds: any;

    constructor(
        private _locationHttpService: LocationSetHttpService,
        private _loadingWrapperService: LoadingWrapperService,
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
            this.setBounds();
            this.project = data.project;
        });
    }

    getLocationSet(){
        this._loadingWrapperService.Load(
            this._locationHttpService.get(this.locationSet.id),
            (data) => {
                this.locationSet = data;
                this.viewLocationSet = new LocationSet({
                    id: data.id,
                    name: data.name,
                    description: data.description,
                    latLng: data.latLng,
                    locationId: data.location.id,
                    scriptLocationId: data.scriptLocation.id
                });
            }
        );
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
    
    public setBounds(){
        if(this.locationSet.location.latLng.hasLatLng && this.locationSet.latLng.hasLatLng){
            this.bounds = MapsHelpers.getBounds([this.locationSet.location.latLng, this.locationSet.latLng]);
        }
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canEditGeneral
        );
    }
}