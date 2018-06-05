import { Component, ViewChild, OnInit } from '@angular/core';
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
import { ProjectPermissionEnum }
    from '../../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';
import { ParentCommentType } from '../../../../../../shared/enums/parent-comment-type.enum';
import { MdDialog } from '@angular/material';
import { SearchLatLngDialogComponent } from '../../../../../../locations';
import { Address, LatLng } from '../../../../../../shared';
import { AgmMap } from '@agm/core';

@Component({
    templateUrl: 'location-landing.component.html',
})
export class LocationLandingComponent implements OnInit {
    @ViewChild('AgmMap') public agmMap: any;

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
        private _dialog: MdDialog,
        private _route: ActivatedRoute,
        private _router: Router
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: { location: FullLocation, project: ProjectSummary }) => {
            this.setLocation(data.location);
            this.project = data.project;
        });
    }

    public setLocation(location) {
        this.location = location;
        this.viewLocation = new Location(location);
        this.setBounds();
    }

    public getLocation() {
        this._loadingWrapperService.Load(
            this._locationHttpService.get(this.location.id),
            (data) => {
                this.setLocation(data);
            }
        );
    }

    public updateLocation() {
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

    public getCanComment() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.CanComment
        );
    }

    public getParentCommentType() {
        return ParentCommentType.location;
    }

    public showAddLatLng() {
        this.showLatLngDialog({
            searchText: this.getAddressString(this.location.address)
        });
    }

    public showUpdateLatLng() {
        this.showLatLngDialog({
            latLng: this.viewLocation.latLng
        });
    }

    private showLatLngDialog(data: any) {
        let addProjectDialog = this._dialog.open(SearchLatLngDialogComponent, {
            data,
            width: SearchLatLngDialogComponent.width
        });
        addProjectDialog.afterClosed().subscribe((chosenLatLng: LatLng) => {
            if (chosenLatLng) {
                this.viewLocation.latLng = chosenLatLng;
                this.updateLocation();
            }
        });
    }

    private getAddressString(address: Address) {
        let result = '';
        if (address.address1) {
            result += ` ${address.address1}`;
        }
        if (address.address2) {
            result += ` ${address.address2}`;
        }
        if (address.address3) {
            result += ` ${address.address3}`;
        }
        if (address.address4) {
            result += ` ${address.address4}`;
        }
        return result;
    }
}