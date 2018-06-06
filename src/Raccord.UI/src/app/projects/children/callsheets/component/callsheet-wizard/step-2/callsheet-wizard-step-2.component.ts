import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CallsheetSceneHttpService } from
    '../../../children/callsheet-scenes/service/callsheet-scene-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { CallsheetSummary } from '../../../';
import { CallsheetScene } from '../../../';
import { CallsheetSceneLocation } from '../../../';
import { LocationSetSummary } from
    '../../../../locations/location-sets/model/location-set-summary.model';
import { Location } from '../../../../locations/locations/model/location.model';
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';
import { Marker } from '../../../../../../locations/model/marker.model';
import { MapsHelpers } from '../../../../../../shared/helpers/maps.helpers';

@Component({
    templateUrl: 'callsheet-wizard-step-2.component.html',
})
export class CallsheetWizardStep2Component implements OnInit {

    public project: ProjectSummary;
    public callsheet: CallsheetSummary;
    public scenes: CallsheetSceneLocation[] = [];
    public locations: LocationWrapper[] = [];
    public bounds: any;
    public markers: Marker[] = [];

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
        private _callsheetSceneHttpService: CallsheetSceneHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            project: ProjectSummary,
            callsheet: CallsheetSummary,
            scenes: CallsheetSceneLocation[]
        }) => {
            this.project = data.project;
            this.callsheet = data.callsheet;
            this.scenes = data.scenes;
            this.setLocations();
        });
    }

    public getScenes() {
        this._loadingWrapperService.Load(
            this._callsheetSceneHttpService.getLocations(this.callsheet.id),
            (data) => {
                this.scenes = data;
                this.setLocations();
            }
        );
    }

    public setLocations() {
        this.locations = this.getLocations();
        this.setBounds();
    }

    public getLocations(): LocationWrapper[] {
        let locations: LocationWrapper[] = [];
        this.scenes.forEach((scene: CallsheetSceneLocation) => {
            let currentSceneLocation =
                scene.locationSet.id !== 0 ? scene.locationSet.location : null;
            if (currentSceneLocation && (locations.length === 0 ||
                locations[locations.length - 1].id !== currentSceneLocation.id)) {
                locations.push(new LocationWrapper(currentSceneLocation, locations.length + 1));
            }
        });
        return locations;
    }

    public updateLocationSet(callsheetScene: CallsheetSceneLocation) {
        if (callsheetScene.locationSet.id !== 0) {
            let loadingId = this._loadingService.startLoading();
            let sceneToUpdate = new CallsheetScene();
            sceneToUpdate.id = callsheetScene.id;
            sceneToUpdate.pageLength = callsheetScene.pageLength;
            sceneToUpdate.locationSetId = callsheetScene.locationSet.id;
            this._loadingWrapperService.Load(
                this._callsheetSceneHttpService.post(sceneToUpdate),
                () => this.getScenes()
            );
        }
    }

    private setBounds() {
        this.markers = this.getMarkers();
        if (this.markers.length) {
            this.bounds =
                MapsHelpers.getBounds(this.markers.map((marker: Marker) => marker.latLng));
        }
    }

    private getMarkers(): Marker[] {
        let locations = this.getLocations();
        let markerLocations = locations.filter((loc: LocationWrapper) => loc.latLng.hasLatLng);
        return markerLocations.map((loc: LocationWrapper) => new Marker({
            label: loc.number.toString(),
            latLng: loc.latLng,
            infoWindow: loc.name
        }));
    }
}

// tslint:disable-next-line:max-classes-per-file
export class LocationWrapper extends Location {
    public number: Number;
    constructor(obj: any, numberOfLocation: Number) {
        super(obj);
        this.number = numberOfLocation;
    }
}
