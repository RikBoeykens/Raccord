import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ScriptLocationHttpService } from '../../service/script-location-http.service';
import { ScriptLocationSummary } from '../../model/script-location-summary.model';
import { ScriptLocation } from '../../model/script-location.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../shared/helpers/html-class.helpers';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';

@Component({
    templateUrl: 'edit-script-locations-list.component.html',
})
export class EditScriptLocationsListComponent implements OnInit {

    scriptLocations: ScriptLocationDroppableWrapper[] = [];
    deleteScriptLocations: ScriptLocationDroppableWrapper[]=[];
    project: ProjectSummary;
    viewNewScriptLocation: ScriptLocation;
    newScriptLocation: ScriptLocation;
    draggingToMerge: boolean;
    draggingToDelete: boolean;

    constructor(
        private _scriptLocationHttpService: ScriptLocationHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private dragulaService: DragulaService
    ) {
        this.viewNewScriptLocation = new ScriptLocation();

        dragulaService.drag.subscribe((value) => {
            this.onScriptLocationDrag(value.splice(1));
        });
        dragulaService.dragend.subscribe(() => {
            this.onScriptLocationDragEnd();
        });
        dragulaService.dropModel.subscribe((value) => {
            this.onScriptLocationDrop(value.slice(1));
        });
        dragulaService.over.subscribe((value) => {
            this.onOver(value.slice(1));
        });
        dragulaService.out.subscribe((value) => {
            this.onOut(value.slice(1));
        });
        const bag: any = this.dragulaService.find('screenplay-location-bag');
        if (bag !== undefined ) this.dragulaService.destroy('screenplay-location-bag');
        dragulaService.setOptions('screenplay-location-bag', {
            moves: function (el, container, handle) {
                return HtmlClassHelpers.hasClass(handle, 'drag-handle');
            }
        });
    }

    ngOnInit() {
        this._route.data.subscribe((data: { scriptLocations: ScriptLocationSummary[], project: ProjectSummary }) => {
            this.scriptLocations = data.scriptLocations.map(function(scripLocation){ return new ScriptLocationDroppableWrapper(scripLocation); });
            this.project = data.project;
            this.resetNewScriptLocation();
        });
    }

    resetNewScriptLocation(){
        this.viewNewScriptLocation = new ScriptLocation();
        this.viewNewScriptLocation.projectID = this.project.id;
        this.newScriptLocation = null;
    }

    getScriptLocations() {
        this._loadingWrapperService.Load(
            this._scriptLocationHttpService.getAll(this.project.id),
            (data) => this.scriptLocations = data.map((scriptLocation) =>
                new ScriptLocationDroppableWrapper(scriptLocation))
        );
    }

    addScriptLocation(){
        let loadingId = this._loadingService.startLoading();

        this.newScriptLocation = this.viewNewScriptLocation;

        this._scriptLocationHttpService.post(this.newScriptLocation).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScriptLocations();
                this.resetNewScriptLocation();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    private onScriptLocationDrag(args) {
        let draggedElement = args[0];
        this.draggingToMerge = true;
        if(draggedElement && HtmlClassHelpers.hasClass(draggedElement, 'can-delete'))
            this.draggingToDelete = true;
    }
    private onScriptLocationDragEnd() {
        this.draggingToMerge = false;
        this.draggingToDelete = false;
    }
    private onScriptLocationDrop(args) {

        // Delete if necessary
        if(this.deleteScriptLocations.length > 0)
            this.remove(this.deleteScriptLocations.splice(0, 1)[0].scriptLocation);

        // Merge if necessary
        var mergeScriptLocationWrapper;
        this.scriptLocations.forEach(function(scriptLocationWrapper){
            if(scriptLocationWrapper.dropScriptLocations.length){
                mergeScriptLocationWrapper = scriptLocationWrapper;
            }
        });
        if(mergeScriptLocationWrapper)
            this.merge(mergeScriptLocationWrapper.scriptLocation, mergeScriptLocationWrapper.dropScriptLocations.splice(0, 1)[0].scriptLocation);
    }
    
    private onOver(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.addClass(el, 'hovering');
    }

    private onOut(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.removeClass(el, 'hovering');
    }

    remove(scriptLocation: ScriptLocationSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove script location ${scriptLocation.name}?`)){

            let loadingId = this._loadingService.startLoading();

            this._scriptLocationHttpService.delete(scriptLocation.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getScriptLocations();
                }else{
                    this._dialogService.success('The script location was successfully removed');
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }else{
            this.getScriptLocations();
        }

    }

    merge(toScriptLocation: ScriptLocationSummary, mergeScriptLocation: ScriptLocationSummary){
        if(this._dialogService.confirm(`Are you sure you want to merge location ${mergeScriptLocation.name} to location ${toScriptLocation.name}?`)){
            let loadingId = this._loadingService.startLoading();

            this._scriptLocationHttpService.merge(toScriptLocation.id, mergeScriptLocation.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getScriptLocations();
                }else{
                    toScriptLocation.sceneCount += mergeScriptLocation.sceneCount;
                    this._dialogService.success('The locations were successfully merged');
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }else{
            this.getScriptLocations();
        }
    }
}

export class ScriptLocationDroppableWrapper{
    scriptLocation: ScriptLocationSummary;
    dropScriptLocations: ScriptLocationSummary[] = [];

    constructor(scriptLocation: ScriptLocationSummary){
        this.scriptLocation = scriptLocation;
    }
}