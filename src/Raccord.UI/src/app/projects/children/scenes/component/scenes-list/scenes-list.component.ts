import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SceneHttpService } from '../../service/scene-http.service';
import { Scene } from '../../model/scene.model';
import { SceneSummary } from '../../model/scene-summary.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../shared/helpers/html-class.helpers';
import { SceneFilterRequest } from '../../model/scene-filter-request.model';
import { BreakdownTypeSummary } from '../../../breakdowns/breakdown-types/model/breakdown-type-summary.model';

@Component({
    templateUrl: 'scenes-list.component.html',
})
export class ScenesListComponent implements OnInit {

    scenes: SceneSummary[] = [];
    deleteScenes: SceneSummary[]=[];
    project: ProjectSummary;
    viewNewScene: Scene;
    newScene: Scene;
    draggingScene: boolean;
    sceneFilter: SceneFilterRequest = new SceneFilterRequest();
    breakdownTypes: BreakdownTypeSummary[];

    constructor(
        private _sceneHttpService: SceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private dragulaService: DragulaService
    ) {
        this.viewNewScene = new Scene();
        dragulaService.drag.subscribe((value) => {
            this.onSceneDrag();
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
        const bag: any = this.dragulaService.find('scene-bag');
        if (bag !== undefined ) this.dragulaService.destroy('scene-bag');
        dragulaService.setOptions('scene-bag', {
            moves: function (el, container, handle) {
                return HtmlClassHelpers.hasClass(handle, 'drag-handle');
            }
        });
    }

    ngOnInit() {
        this._route.data.subscribe((data: { scenes: SceneSummary[], project: ProjectSummary, breakdownTypes: BreakdownTypeSummary[] }) => {
            this.scenes = data.scenes;
            this.project = data.project;
            this.resetNewScene();
            this.sceneFilter.projectID = this.project.id;
            this.breakdownTypes = data.breakdownTypes;
        });
    }

    resetNewScene(){
        this.viewNewScene = new Scene();
        this.viewNewScene.projectId = this.project.id;
        this.viewNewScene.intExt.projectId = this.project.id;
        this.viewNewScene.dayNight.projectId = this.project.id;
        this.viewNewScene.scriptLocation.projectID = this.project.id;
        this.newScene = null;
    }

    getScenes(){
        
        let loadingId = this._loadingService.startLoading();

        this._sceneHttpService.getAll(this.project.id).then(data => {
            this.scenes = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    filterScenes() {
        let loadingId = this._loadingService.startLoading();
        this._sceneHttpService.filter(this.sceneFilter).then(pagedData => {
            this.scenes = pagedData.data;
            this._loadingService.endLoading(loadingId);
        });
    }

    addScene(){
        let loadingId = this._loadingService.startLoading();

        this.newScene = this.viewNewScene;

        this._sceneHttpService.post(this.newScene).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScenes();
                this.resetNewScene();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
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
            this.remove(sceneToDelete);
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

        this._sceneHttpService.sort(this.project.id, this.getSortedOrder()).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }


    remove(scene: SceneSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove scene #${scene.number}`)){

            let loadingId = this._loadingService.startLoading();

            this._sceneHttpService.delete(scene.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getScenes();
                }else{
                    this._dialogService.success('The scene was successfully removed');
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }
        else{
            this.getScenes();
        }

    }

    getSortedOrder():number[]{
        return this.scenes.map(function(scene){
            return scene.id;
        });
    }
}