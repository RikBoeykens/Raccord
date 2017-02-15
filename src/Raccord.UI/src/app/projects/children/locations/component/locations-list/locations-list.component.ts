import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LocationHttpService } from '../../service/location-http.service';
import { LocationSummary } from '../../model/location-summary.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';

@Component({
    templateUrl: 'locations-list.component.html',
})
export class LocationsListComponent extends OnInit {

    locations: LocationSummary[] = [];
    deleteLocations: LocationSummary[]=[];
    project: ProjectSummary;
    viewNewLocation: LocationSummary;
    newLocation: LocationSummary;
    draggingLocation: boolean;

    constructor(
        private _locationHttpService: LocationHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private dragulaService: DragulaService
    ) {
        super();
        this.viewNewLocation = new LocationSummary();
        dragulaService.drag.subscribe((value) => {
            this.onLocationDrag();
        });
        dragulaService.dragend.subscribe(() => {
            this.onLocationDragEnd();
        });
        dragulaService.dropModel.subscribe((value) => {
            this.onLocationDrop(value.slice(1));
        });
    }

    ngOnInit() {
        this._route.data.subscribe((data: { locations: LocationSummary[], project: ProjectSummary }) => {
            this.locations = data.locations;
            this.project = data.project;
            this.resetNewLocation();
        });
    }

    resetNewLocation(){
        this.viewNewLocation = new LocationSummary();
        this.viewNewLocation.projectId = this.project.id;
        this.newLocation = null;
    }

    getLocations(){
        
        let loadingId = this._loadingService.startLoading();

        this._locationHttpService.getAll(this.project.id).then(data => {
            this.locations = data;
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

    private onLocationDrag() {
        this.draggingLocation = true;
    }
    private onLocationDragEnd() {
        this.draggingLocation = false;
    }
    private onLocationDrop(args) {

        // Delete if necessary
        if(this.deleteLocations.length){
            var locationToDelete = this.deleteLocations.splice(0, 1)[0];
            this.remove(locationToDelete);
        }
    }


    remove(location: LocationSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove location #${location.name}`)){

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
        }

    }
}