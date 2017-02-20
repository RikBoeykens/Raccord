import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DayNightHttpService } from '../../service/day-night-http.service';
import { DayNightSummary } from '../../model/day-night-summary.model';
import { DayNight } from '../../model/day-night.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../shared/helpers/html-class.helpers';

@Component({
    templateUrl: 'day-night-list.component.html',
})
export class DayNightListComponent extends OnInit {

    dayNights: DayNightDroppableWrapper[] = [];
    deleteDayNights: DayNightDroppableWrapper[]=[];
    project: ProjectSummary;
    viewNewDayNight: DayNight;
    newDayNight: DayNight;
    draggingToMerge: boolean;
    draggingToDelete: boolean;

    constructor(
        private _dayNightHttpService: DayNightHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private dragulaService: DragulaService
    ) {
        super();
        this.viewNewDayNight = new DayNight();

        dragulaService.drag.subscribe((value) => {
            this.onDayNightDrag(value.splice(1));
        });
        dragulaService.dragend.subscribe(() => {
            this.onDayNightDragEnd();
        });
        dragulaService.dropModel.subscribe((value) => {
            this.onDayNightDrop(value.slice(1));
        });
        dragulaService.over.subscribe((value) => {
            this.onOver(value.slice(1));
        });
        dragulaService.out.subscribe((value) => {
            this.onOut(value.slice(1));
        });
        const bag: any = this.dragulaService.find('day-night-bag');
        if (bag !== undefined ) this.dragulaService.destroy('day-night-bag');
        dragulaService.setOptions('day-night-bag', {
            moves: function (el, container, handle) {
                return HtmlClassHelpers.hasClass(handle, 'drag-handle');
            }
        });
    }

    ngOnInit() {
        this._route.data.subscribe((data: { dayNights: DayNightSummary[], project: ProjectSummary }) => {
            this.dayNights = data.dayNights.map(function(dayNight){ return new DayNightDroppableWrapper(dayNight); });
            this.project = data.project;
            this.resetNewDayNight();
        });
    }

    resetNewDayNight(){
        this.viewNewDayNight = new DayNight();
        this.viewNewDayNight.projectId = this.project.id;
        this.newDayNight = null;
    }

    getDayNights(){
        
        let loadingId = this._loadingService.startLoading();

        this._dayNightHttpService.getAll(this.project.id).then(data => {
            this.dayNights = data.map(function(dayNight){ return new DayNightDroppableWrapper(dayNight); });
            this._loadingService.endLoading(loadingId);
        });
    }

    addDayNight(){
        let loadingId = this._loadingService.startLoading();

        this.newDayNight = this.viewNewDayNight;

        this._dayNightHttpService.post(this.newDayNight).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getDayNights();
                this.resetNewDayNight();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    private onDayNightDrag(args) {
        let draggedElement = args[0];
        this.draggingToMerge = true;
        if(draggedElement && HtmlClassHelpers.hasClass(draggedElement, 'can-delete'))
            this.draggingToDelete = true;
    }
    private onDayNightDragEnd() {
        this.draggingToMerge = false;
        this.draggingToDelete = false;
    }
    private onDayNightDrop(args) {

        // Delete if necessary
        if(this.deleteDayNights.length > 0)
            this.remove(this.deleteDayNights.splice(0, 1)[0].dayNight);

        // Merge if necessary
        var mergeDayNightWrapper;
        this.dayNights.forEach(function(dayNightWrapper){
            if(dayNightWrapper.dropDayNights.length){
                mergeDayNightWrapper = dayNightWrapper;
            }
        });
        if(mergeDayNightWrapper)
            this.merge(mergeDayNightWrapper.dayNight, mergeDayNightWrapper.dropDayNights.splice(0, 1)[0].dayNight);
    }
    
    private onOver(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.addClass(el, 'hovering');
    }

    private onOut(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.removeClass(el, 'hovering');
    }

    remove(dayNight: DayNightSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove day/night ${dayNight.name}?`)){

            let loadingId = this._loadingService.startLoading();

            this._dayNightHttpService.delete(dayNight.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getDayNights();
                }else{
                    this._dialogService.success('The day/night was successfully removed');
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }else{
            this.getDayNights();
        }

    }

    merge(toDayNight: DayNightSummary, mergeDayNight: DayNightSummary){
        if(this._dialogService.confirm(`Are you sure you want to merge day/night ${mergeDayNight.name} to ${toDayNight.name}?`)){
            let loadingId = this._loadingService.startLoading();

            this._dayNightHttpService.merge(toDayNight.id, mergeDayNight.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getDayNights();
                }else{
                    toDayNight.sceneCount += mergeDayNight.sceneCount;
                    this._dialogService.success('The day/nights were successfully merged');
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }else{
            this.getDayNights();
        }
    }
}

export class DayNightDroppableWrapper{
    dayNight: DayNightSummary;
    dropDayNights: DayNightSummary[] = [];

    constructor(dayNight: DayNightSummary){
        this.dayNight = dayNight;
    }
}