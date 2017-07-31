import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { FullCallsheet } from "../../";
import { CallsheetSceneScene } from "../../";
import { Location } from "../../../locations/locations/model/location.model";

@Component({
    templateUrl: 'callsheet.component.html',
})
export class CallsheetComponent implements OnInit {

    project: ProjectSummary;
    callsheet: FullCallsheet;

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, callsheet: FullCallsheet }) => {
            this.project = data.project;
            this.callsheet = data.callsheet;
        });
    }


    getLocations(){
        let locations:  Location[] = [];
        this.callsheet.scenes.forEach((scene: CallsheetSceneScene)=> {
            let currentSceneLocation = scene.locationSet.id!==0 ? scene.locationSet.location : null;
            if(currentSceneLocation&&(locations.length===0 || locations[locations.length - 1].id !== currentSceneLocation.id)){
                locations.push(currentSceneLocation);
            }
        });
        return locations;
    }
}