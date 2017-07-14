import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CallsheetHttpService } from "../../../service/callsheet-http.service";
import { CallsheetSceneHttpService } from "../../../children/callsheet-scenes/service/callsheet-scene-http.service";
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { FullCallsheet } from "../../../";
import { CallsheetScene } from "../../../";
import { CallsheetSceneScene } from "../../../";
import { SelectedEntity } from '../../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../../shared/enums/entity-type.enum';
import { PageLengthHelpers } from '../../../../../../shared/helpers/page-length.helpers';

@Component({
    templateUrl: 'callsheet-wizard-step-1.component.html',
})
export class CallsheetWizardStep1Component implements OnInit {

    project: ProjectSummary;
    callsheet: FullCallsheet;
    callsheetScenes: CallsheetSceneScene[]=[];
    sceneType: EntityType[] = [EntityType.scene];

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
        private _callsheetHttpService: CallsheetHttpService,
        private _callsheetSceneHttpService: CallsheetSceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary, callsheet: FullCallsheet }) => {
            this.project = data.project;
            this.callsheet = data.callsheet;
            this.callsheetScenes = data.callsheet.scenes.map((callsheetScene: CallsheetSceneScene)=> new CallsheetSceneWrapper(callsheetScene));
        });
    }

    getScenes(){
        let loadingId = this._loadingService.startLoading();

        this._callsheetSceneHttpService.getScenes(this.callsheet.id).then(data => {
            this.callsheetScenes = data.map((callsheetScene: CallsheetSceneScene)=> new CallsheetSceneWrapper(callsheetScene));
            this._loadingService.endLoading(loadingId);
        });
    }

    addCallsheetScene(scene: SelectedEntity){
        let loadingId = this._loadingService.startLoading();

        let newCallsheetScene = new CallsheetScene();
        newCallsheetScene.sceneId = scene.entityId;
        newCallsheetScene.callsheetId = this.callsheet.id;

        this._callsheetSceneHttpService.post(newCallsheetScene).then(data=>{
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

    removeCallsheetScene(callsheetScene: CallsheetScene){
        let loadingId = this._loadingService.startLoading();

        this._callsheetSceneHttpService.delete(callsheetScene.id).then(data=>{
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

    getScheduledPageLength(){
        let sum = 0;
        this.callsheetScenes.map((scene: CallsheetSceneScene)=> sum+=scene.pageLength);
        return sum;
    }

    updatePageLength(callsheetScene: CallsheetSceneWrapper){
        let sceneToUpdate = new CallsheetScene();
        sceneToUpdate.id = callsheetScene.id;
        sceneToUpdate.pageLength = PageLengthHelpers.getPageLengthNumber(callsheetScene.stringPageLength);

        let loadingId = this._loadingService.startLoading();
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

class CallsheetSceneWrapper extends CallsheetSceneScene{
    stringPageLength: string;

    constructor(callsheetScene: CallsheetSceneScene){
        super(callsheetScene);
        this.stringPageLength = PageLengthHelpers.getPageLengthString(callsheetScene.pageLength);
    }
}