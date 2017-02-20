import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LocationHttpService } from '../../service/location-http.service';
import { LocationSummary } from '../../model/location-summary.model';
import { Location } from '../../model/location.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../shared/helpers/html-class.helpers';

@Component({
    templateUrl: 'locations-list.component.html',
})
export class LocationsListComponent extends OnInit {

    locations: LocationDroppableWrapper[] = [];
    deleteLocations: LocationDroppableWrapper[]=[];
    project: ProjectSummary;
    viewNewLocation: Location;
    newLocation: Location;
    draggingToMerge: boolean;
    draggingToDelete: boolean;

    constructor(
        private _locationHttpService: LocationHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private dragulaService: DragulaService
    ) {
        super();
        this.viewNewLocation = new Location();

        dragulaService.drag.subscribe((value) => {
            this.onLocationDrag(value.splice(1));
        });
        dragulaService.dragend.subscribe(() => {
            this.onLocationDragEnd();
        });
        dragulaService.dropModel.subscribe((value) => {
            this.onLocationDrop(value.slice(1));
        });
        dragulaService.over.subscribe((value) => {
            this.onOver(value.slice(1));
        });
        dragulaService.out.subscribe((value) => {
            this.onOut(value.slice(1));
        });
        const bag: any = this.dragulaService.find('location-bag');
        if (bag !== undefined ) this.dragulaService.destroy('location-bag');
        dragulaService.setOptions('location-bag', {
            moves: function (el, container, handle) {
                return HtmlClassHelpers.hasClass(handle, 'drag-handle');
            }
        });
    }

    ngOnInit() {
        this._route.data.subscribe((data: { locations: LocationSummary[], project: ProjectSummary }) => {
            this.locations = data.locations.map(function(location){ return new LocationDroppableWrapper(location); });
            this.project = data.project;
            this.resetNewLocation();
        });
    }

    resetNewLocation(){
        this.viewNewLocation = new Location();
        this.viewNewLocation.projectId = this.project.id;
        this.newLocation = null;
    }

    getLocations(){
        
        let loadingId = this._loadingService.startLoading();

        this._locationHttpService.getAll(this.project.id).then(data => {
            this.locations = data.map(function(location){ return new LocationDroppableWrapper(location); });
            this._loadingService.endLoading(loadingId);
        });
    }

    addLocation(){
        let loadingId = this._loadingService.startLoading();

        this.newLocation = this.viewNewLocation;

        this._locationHttpService.post(this.newLocation).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getLocations();
                this.resetNewLocation();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    private onLocationDrag(args) {
        let draggedElement = args[0];
        this.draggingToMerge = true;
        if(draggedElement && HtmlClassHelpers.hasClass(draggedElement, 'can-delete'))
            this.draggingToDelete = true;
    }
    private onLocationDragEnd() {
        this.draggingToMerge = false;
        this.draggingToDelete = false;
    }
    private onLocationDrop(args) {

        // Delete if necessary
        if(this.deleteLocations.length > 0)
            this.remove(this.deleteLocations.splice(0, 1)[0].location);

        // Merge if necessary
        var mergeLocationWrapper;
        this.locations.forEach(function(locationWrapper){
            if(locationWrapper.dropLocations.length){
                mergeLocationWrapper = locationWrapper;
            }
        });
        if(mergeLocationWrapper)
            this.merge(mergeLocationWrapper.location, mergeLocationWrapper.dropLocations.splice(0, 1)[0].location);
    }
    
    private onOver(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.addClass(el, 'hovering');
    }

    private onOut(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.removeClass(el, 'hovering');
    }

    remove(location: LocationSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove location ${location.name}?`)){

            let loadingId = this._loadingService.startLoading();

            this._locationHttpService.delete(location.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getLocations();
                }else{
                    this._dialogService.success('The location was successfully removed');
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }else{
            this.getLocations();
        }

    }

    merge(toLocation: LocationSummary, mergeLocation: LocationSummary){
        if(this._dialogService.confirm(`Are you sure you want to merge location ${mergeLocation.name} to location ${toLocation.name}?`)){
            let loadingId = this._loadingService.startLoading();

            this._locationHttpService.merge(toLocation.id, mergeLocation.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getLocations();
                }else{
                    toLocation.sceneCount += mergeLocation.sceneCount;
                    this._dialogService.success('The locations were successfully merged');
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }else{
            this.getLocations();
        }
    }
}

export class LocationDroppableWrapper{
    location: LocationSummary;
    dropLocations: LocationSummary[] = [];

    constructor(location: LocationSummary){
        this.location = location;
    }
}