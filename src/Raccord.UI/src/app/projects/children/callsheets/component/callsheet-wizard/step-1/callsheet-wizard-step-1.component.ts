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
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../../shared/helpers/html-class.helpers';

@Component({
    templateUrl: 'callsheet-wizard-step-1.component.html',
})
export class CallsheetWizardStep1Component implements OnInit {

    project: ProjectSummary;
    callsheet: FullCallsheet;
    callsheetScenes: CallsheetSceneWrapper[]=[];
    sceneType: EntityType[] = [EntityType.scene];
    draggingScene: boolean;
    deleteScenes: CallsheetSceneWrapper[]=[];

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
        private _callsheetHttpService: CallsheetHttpService,
        private _callsheetSceneHttpService: CallsheetSceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private dragulaService: DragulaService
    ) {
        dragulaService.drag.subscribe((value) => {
            this.onSceneDrag();
            console.log("dragging started");
        });
        dragulaService.dragend.subscribe(() => {
            this.onSceneDragEnd();
        });
        dragulaService.dropModel.subscribe((value) => {
            this.onSceneDrop(value.slice(1));
        });
        dragulaService.over.subscribe((value) => {
            this.onOver(value.slice(1));
        });
        dragulaService.out.subscribe((value) => {
            this.onOut(value.slice(1));
        });
        const bag: any = this.dragulaService.find('callsheet-scene-bag');
        if (bag !== undefined ) this.dragulaService.destroy('callsheet-scene-bag');
        dragulaService.setOptions('callsheet-scene-bag', {
            moves: function (el, container, handle) {
                return HtmlClassHelpers.hasClass(handle, 'drag-handle');
            }
        });
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

    removeCallsheetScene(callsheetScene: CallsheetSceneWrapper){
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
        let newPageLength = PageLengthHelpers.getPageLengthNumber(callsheetScene.stringPageLength);

        if(newPageLength && newPageLength!==callsheetScene.pageLength){
            let loadingId = this._loadingService.startLoading();
            let sceneToUpdate = new CallsheetScene();
            sceneToUpdate.id = callsheetScene.id;
            sceneToUpdate.pageLength = newPageLength;

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

    private onSceneDrag() {
        this.draggingScene = true;
    }
    private onSceneDragEnd() {
        this.draggingScene = false;
    }
    private onSceneDrop(args) {
        //update sorting
        this.sortScenes();

        // Delete if necessary
        if(this.deleteScenes.length){
            var sceneToDelete = this.deleteScenes.splice(0, 1)[0];
            this.removeCallsheetScene(sceneToDelete);
        }
    }
    
    private onOver(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.addClass(el, 'hovering');
    }

    private onOut(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.removeClass(el, 'hovering');
    }

    sortScenes(){
        let loadingId = this._loadingService.startLoading();

        this._callsheetSceneHttpService.sort(this.project.id, this.getSortedOrder()).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    getSortedOrder():number[]{
        return this.callsheetScenes.map(function(scene){
            return scene.id;
        });
    }
}

class CallsheetSceneWrapper extends CallsheetSceneScene{
    stringPageLength: string;

    constructor(callsheetScene: CallsheetSceneScene){
        super(callsheetScene);
        this.stringPageLength = PageLengthHelpers.getPageLengthString(callsheetScene.pageLength);
    }
}