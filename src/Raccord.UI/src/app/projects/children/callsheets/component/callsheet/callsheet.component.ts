import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { FullCallsheet } from "../../";
import { CallsheetSceneScene } from "../../";
import { Location } from "../../../locations/locations/model/location.model";
import { CallsheetLocation } from '../../../locations/locations/model/callsheet-location.model';
import { MapsHelpers } from '../../../../../shared/helpers/maps.helpers';

@Component({
    templateUrl: 'callsheet.component.html',
})
export class CallsheetComponent implements OnInit {

    project: ProjectSummary;
    callsheet: FullCallsheet;
    bounds: any;
    markerLocations: CallsheetLocation[] = [];

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, callsheet: FullCallsheet }) => {
            this.project = data.project;
            this.callsheet = data.callsheet;
            this.setBounds();
        });
    }


    getLocations(){
        let locations:  Location[] = [];
        this.callsheet.scenes.forEach((scene: CallsheetSceneScene)=> {
            let currentSceneLocation = scene.locationSet.id!==0 ? scene.locationSet.location : null;
            if(currentSceneLocation && (locations.length === 0 || locations[locations.length - 1].id !== currentSceneLocation.id)){
                locations.push(currentSceneLocation);
            }
        });
        return locations;
    }

    public setBounds(){
        this.markerLocations = this.callsheet.locations.filter(l => l.latLng.hasLatLng);
        if(this.markerLocations.length){
            this.bounds = MapsHelpers.getBounds(this.markerLocations.map((location) => location.latLng));
        }
    }
}