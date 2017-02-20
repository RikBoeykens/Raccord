import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IntExtHttpService } from '../../service/int-ext-http.service';
import { IntExtSummary } from '../../model/int-ext-summary.model';
import { IntExt } from '../../model/int-ext.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../shared/helpers/html-class.helpers';

@Component({
    templateUrl: 'int-ext-list.component.html',
})
export class IntExtListComponent extends OnInit {

    intExts: IntExtDroppableWrapper[] = [];
    deleteIntExts: IntExtDroppableWrapper[]=[];
    project: ProjectSummary;
    viewNewIntExt: IntExt;
    newIntExt: IntExt;
    draggingToMerge: boolean;
    draggingToDelete: boolean;

    constructor(
        private _intExtHttpService: IntExtHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private dragulaService: DragulaService
    ) {
        super();
        this.viewNewIntExt = new IntExt();

        dragulaService.drag.subscribe((value) => {
            this.onIntExtDrag(value.splice(1));
        });
        dragulaService.dragend.subscribe(() => {
            this.onIntExtDragEnd();
        });
        dragulaService.dropModel.subscribe((value) => {
            this.onIntExtDrop(value.slice(1));
        });
        dragulaService.over.subscribe((value) => {
            this.onOver(value.slice(1));
        });
        dragulaService.out.subscribe((value) => {
            this.onOut(value.slice(1));
        });
        const bag: any = this.dragulaService.find('int-ext-bag');
        if (bag !== undefined ) this.dragulaService.destroy('int-ext-bag');
        dragulaService.setOptions('int-ext-bag', {
            moves: function (el, container, handle) {
                return HtmlClassHelpers.hasClass(handle, 'drag-handle');
            }
        });
    }

    ngOnInit() {
        this._route.data.subscribe((data: { intExts: IntExtSummary[], project: ProjectSummary }) => {
            this.intExts = data.intExts.map(function(intExt){ return new IntExtDroppableWrapper(intExt); });
            this.project = data.project;
            this.resetNewIntExt();
        });
    }

    resetNewIntExt(){
        this.viewNewIntExt = new IntExt();
        this.viewNewIntExt.projectId = this.project.id;
        this.newIntExt = null;
    }

    getIntExts(){
        
        let loadingId = this._loadingService.startLoading();

        this._intExtHttpService.getAll(this.project.id).then(data => {
            this.intExts = data.map(function(intExt){ return new IntExtDroppableWrapper(intExt); });
            this._loadingService.endLoading(loadingId);
        });
    }

    addIntExt(){
        let loadingId = this._loadingService.startLoading();

        this.newIntExt = this.viewNewIntExt;

        this._intExtHttpService.post(this.newIntExt).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getIntExts();
                this.resetNewIntExt();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    private onIntExtDrag(args) {
        let draggedElement = args[0];
        this.draggingToMerge = true;
        if(draggedElement && HtmlClassHelpers.hasClass(draggedElement, 'can-delete'))
            this.draggingToDelete = true;
    }
    private onIntExtDragEnd() {
        this.draggingToMerge = false;
        this.draggingToDelete = false;
    }
    private onIntExtDrop(args) {

        // Delete if necessary
        if(this.deleteIntExts.length > 0)
            this.remove(this.deleteIntExts.splice(0, 1)[0].intExt);

        // Merge if necessary
        var mergeIntExtWrapper;
        this.intExts.forEach(function(intExtWrapper){
            if(intExtWrapper.dropIntExts.length){
                mergeIntExtWrapper = intExtWrapper;
            }
        });
        if(mergeIntExtWrapper)
            this.merge(mergeIntExtWrapper.intExt, mergeIntExtWrapper.dropIntExts.splice(0, 1)[0].intExt);
    }
    
    private onOver(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.addClass(el, 'hovering');
    }

    private onOut(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.removeClass(el, 'hovering');
    }

    remove(intExt: IntExtSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove int/ext ${intExt.name}?`)){

            let loadingId = this._loadingService.startLoading();

            this._intExtHttpService.delete(intExt.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getIntExts();
                }else{
                    this._dialogService.success('The int/ext was successfully removed');
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }else{
            this.getIntExts();
        }

    }

    merge(toIntExt: IntExtSummary, mergeIntExt: IntExtSummary){
        if(this._dialogService.confirm(`Are you sure you want to merge int/ext ${mergeIntExt.name} to ${toIntExt.name}?`)){
            let loadingId = this._loadingService.startLoading();

            this._intExtHttpService.merge(toIntExt.id, mergeIntExt.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getIntExts();
                }else{
                    toIntExt.sceneCount += mergeIntExt.sceneCount;
                    this._dialogService.success('The int/exts were successfully merged');
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }else{
            this.getIntExts();
        }
    }
}

export class IntExtDroppableWrapper{
    intExt: IntExtSummary;
    dropIntExts: IntExtSummary[] = [];

    constructor(intExt: IntExtSummary){
        this.intExt = intExt;
    }
}