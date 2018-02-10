import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BreakdownTypeHttpService } from '../../service/breakdown-type-http.service';
import { BreakdownItemHttpService } from '../../../breakdown-items/service/breakdown-item-http.service';
import { LoadingService } from '../../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';
import { FullBreakdownType } from '../../model/full-breakdown-type.model';
import { BreakdownItemSummary } from '../../../breakdown-items/model/breakdown-item-summary.model';
import { BreakdownItem } from '../../../breakdown-items/model/breakdown-item.model';
import { ProjectSummary } from '../../../../../../model/project-summary.model';
import { HtmlClassHelpers } from '../../../../../../../shared/helpers/html-class.helpers';
import { AccountHelpers } from '../../../../../../../account/helpers/account.helper';

@Component({
    templateUrl: 'breakdown-type-landing.component.html',
})
export class BreakdownTypeLandingComponent {

    breakdownType: FullBreakdownType;
    breakdownItems: BreakdownItemDroppableWrapper[] = [];
    deleteBreakdownItems: BreakdownItemDroppableWrapper[] = [];
    project: ProjectSummary;

    viewNewBreakdownItem: BreakdownItem;
    newBreakdownItem: BreakdownItem;

    draggingToMerge: boolean;
    draggingToDelete: boolean;

    constructor(
        private _breakdownTypeHttpService: BreakdownTypeHttpService,
        private _breakdownItemHttpService: BreakdownItemHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private dragulaService: DragulaService
    ){
        this.viewNewBreakdownItem = new BreakdownItem();

        dragulaService.drag.subscribe((value) => {
            this.onBreakdownItemDrag(value.splice(1));
        });
        dragulaService.dragend.subscribe(() => {
            this.onBreakdownItemDragEnd();
        });
        dragulaService.dropModel.subscribe((value) => {
            this.onBreakdownItemDrop(value.slice(1));
        });
        dragulaService.over.subscribe((value) => {
            this.onOver(value.slice(1));
        });
        dragulaService.out.subscribe((value) => {
            this.onOut(value.slice(1));
        });
        const bag: any = this.dragulaService.find('breakdown-item-bag');
        if (bag !== undefined ) this.dragulaService.destroy('breakdown-item-bag');
        dragulaService.setOptions('breakdown-item-bag', {
            moves: function (el, container, handle) {
                return HtmlClassHelpers.hasClass(handle, 'drag-handle');
            }
        });
    }

    ngOnInit() {
        this._route.data.subscribe((data: { breakdownType: FullBreakdownType, project: ProjectSummary }) => {
            this.breakdownType = data.breakdownType;
            this.breakdownItems = data.breakdownType.breakdownItems.map(function(breakdownItem){ return new BreakdownItemDroppableWrapper(breakdownItem); });
            this.project = data.project;
            this.resetNewBreakdownItem();
        });
    }

    resetNewBreakdownItem(){
        this.viewNewBreakdownItem = new BreakdownItem();
        this.viewNewBreakdownItem.breakdownID = this.breakdownType.breakdown.id;
        this.viewNewBreakdownItem.breakdownTypeID = this.breakdownType.id;
        this.newBreakdownItem = null;
    }

    getBreakdownType(){
        let loadingId = this._loadingService.startLoading();

        this._breakdownTypeHttpService.get(this.breakdownType.id).then(data => {
            this.breakdownType = data;
            this.breakdownItems = data.breakdownItems.map(function(breakdownItem){ return new BreakdownItemDroppableWrapper(breakdownItem); });

            this._loadingService.endLoading(loadingId);
        });
    }

    addBreakdownItem(){
        let loadingId = this._loadingService.startLoading();

        this.newBreakdownItem = this.viewNewBreakdownItem;

        this._breakdownItemHttpService.post(this.newBreakdownItem).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getBreakdownType();
                this.resetNewBreakdownItem();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    userCanEdit() {
        return this.breakdownType.breakdown.createdBy.id === AccountHelpers.getUserId();
    }

    private onBreakdownItemDrag(args) {
        let draggedElement = args[0];
        this.draggingToMerge = true;
        if(draggedElement && HtmlClassHelpers.hasClass(draggedElement, 'can-delete'))
            this.draggingToDelete = true;
    }
    private onBreakdownItemDragEnd() {
        this.draggingToMerge = false;
        this.draggingToDelete = false;
    }
    private onBreakdownItemDrop(args) {

        // Delete if necessary
        if(this.deleteBreakdownItems.length > 0)
            this.remove(this.deleteBreakdownItems.splice(0, 1)[0].breakdownItem);

        // Merge if necessary
        var mergeBreakdownItemWrapper;
        this.breakdownItems.forEach(function(breakdownItemWrapper){
            if(breakdownItemWrapper.dropBreakdownItems.length){
                mergeBreakdownItemWrapper = breakdownItemWrapper;
            }
        });
        if(mergeBreakdownItemWrapper)
            this.merge(mergeBreakdownItemWrapper.breakdownItem, mergeBreakdownItemWrapper.dropBreakdownItems.splice(0, 1)[0].breakdownItem);
    }
    
    private onOver(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.addClass(el, 'hovering');
    }

    private onOut(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.removeClass(el, 'hovering');
    }

    remove(breakdownItem: BreakdownItemSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove breakdown item ${breakdownItem.name}?`)){

            let loadingId = this._loadingService.startLoading();

            this._breakdownItemHttpService.delete(breakdownItem.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getBreakdownType();
                }else{
                    this._dialogService.success('The breakdown item was successfully removed');
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }else{
            this.getBreakdownType();
        }

    }

    merge(toBreakdownItem: BreakdownItemSummary, mergeBreakdownItem: BreakdownItemSummary){
        if(this._dialogService.confirm(`Are you sure you want to merge breakdown item ${mergeBreakdownItem.name} to breakdown item ${toBreakdownItem.name}?`)){
            let loadingId = this._loadingService.startLoading();

            this._breakdownItemHttpService.merge(toBreakdownItem.id, mergeBreakdownItem.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getBreakdownType();
                }else{
                    toBreakdownItem.sceneCount += mergeBreakdownItem.sceneCount;
                    this._dialogService.success('The breakdown items were successfully merged');
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }else{
            this.getBreakdownType();
        }
    }
}

export class BreakdownItemDroppableWrapper{
    breakdownItem: BreakdownItemSummary;
    dropBreakdownItems: BreakdownItemSummary[] = [];

    constructor(breakdownItem: BreakdownItemSummary){
        this.breakdownItem = breakdownItem;
    }
}