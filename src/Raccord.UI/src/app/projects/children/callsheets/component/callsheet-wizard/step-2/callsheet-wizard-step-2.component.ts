import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CallsheetSceneHttpService } from "../../../children/callsheet-scenes/service/callsheet-scene-http.service";
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { CallsheetSummary } from "../../../";
import { CallsheetScene } from "../../../";
import { CallsheetSceneLocation } from "../../../";
import { LocationSetSummary } from "../../../../locations/location-sets/model/location-set-summary.model";
import { Location } from "../../../../locations/locations/model/location.model";
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';

@Component({
    templateUrl: 'callsheet-wizard-step-2.component.html',
})
export class CallsheetWizardStep2Component implements OnInit {

    project: ProjectSummary;
    callsheet: CallsheetSummary;
    scenes: CallsheetSceneLocation[] = [];

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
        private _callsheetSceneHttpService: CallsheetSceneHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, callsheet: CallsheetSummary, scenes: CallsheetSceneLocation[] }) => {
            this.project = data.project;
            this.callsheet = data.callsheet;
            this.scenes = data.scenes;
        });
    }

    getScenes(){
        this._loadingWrapperService.Load(
            this._callsheetSceneHttpService.getLocations(this.callsheet.id),
            (data) => this.scenes = data
        );
    }

    getLocations(){
        let locations:  Location[] = [];
        this.scenes.forEach((scene: CallsheetSceneLocation)=> {
            let currentSceneLocation = scene.locationSet.id!==0 ? scene.locationSet.location : null;
            if(currentSceneLocation&&(locations.length===0 || locations[locations.length - 1].id !== currentSceneLocation.id)){
                locations.push(currentSceneLocation);
            }
        });
        return locations;
    }

    updateLocationSet(callsheetScene: CallsheetSceneLocation){

        if(callsheetScene.locationSet.id!==0){
            let loadingId = this._loadingService.startLoading();
            let sceneToUpdate = new CallsheetScene();
            sceneToUpdate.id = callsheetScene.id;
            sceneToUpdate.pageLength = callsheetScene.pageLength;
            sceneToUpdate.locationSetId = callsheetScene.locationSet.id;

            this._callsheetSceneHttpService.post(sceneToUpdate).then(data=>{
                if(typeof(data)=='string'){
                    this._dialogService.error(data);
                }else{
                    this.getScenes();
                }
            }).catch()
            .then(()=>
                this._loadingService.endLoading(loadingId)
            );
        }
    }
}