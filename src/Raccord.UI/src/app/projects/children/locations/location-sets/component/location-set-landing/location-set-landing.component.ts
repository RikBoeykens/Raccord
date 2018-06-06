import { Component, OnInit } from '@angular/core';
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
import { ProjectPermissionEnum } from
    '../../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';
import { MdDialog } from '@angular/material';
import { SearchLatLngDialogComponent } from '../../../../../../locations/component/search-lat-lng-dialog/search-lat-lng-dialog.component';
import { LatLng } from '../../../../../../shared/model/lat-lng.model';

@Component({
    templateUrl: 'location-set-landing.component.html',
})
export class LocationSetLandingComponent implements OnInit {

    public locationSet: FullLocationSet;
    public viewLocationSet: LocationSet;
    public project: ProjectSummary;
    public bounds: any;

    constructor(
        private _locationHttpService: LocationSetHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private _dialog: MdDialog
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            locationSet: FullLocationSet,
            project: ProjectSummary
        }) => {
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

    public getLocationSet() {
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
                this.setBounds();
            }
        );
    }

    public updateLocationSet() {
        this._loadingWrapperService.Load(
            this._locationHttpService.post(this.viewLocationSet),
            (data) => this.getLocationSet()
        );
    }

    public setBounds() {
        if (this.locationSet.location.latLng.hasLatLng) {
            let markers = [this.locationSet.location.latLng];
            if (this.locationSet.latLng.hasLatLng) {
                markers.push(this.locationSet.latLng);
            }
            this.bounds =
                MapsHelpers.getBounds(markers);
        }
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canEditGeneral
        );
    }

    public showAddLatLng() {
        this.showLatLngDialog({
            latLng: this.locationSet.location.latLng
        });
    }

    public showUpdateLatLng() {
        this.showLatLngDialog({
            latLng: this.locationSet.latLng
        });
    }

    private showLatLngDialog(data: any) {
        let addProjectDialog = this._dialog.open(SearchLatLngDialogComponent, {
            data,
            width: SearchLatLngDialogComponent.width
        });
        addProjectDialog.afterClosed().subscribe((chosenLatLng: LatLng) => {
            if (chosenLatLng) {
                this.viewLocationSet.latLng = chosenLatLng;
                this.updateLocationSet();
            }
        });
    }
}
