import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LocationHttpService } from '../../service/location-http.service';
import { LocationSummary } from '../../../';
import { Location } from '../../../';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../../shared/helpers/html-class.helpers';
import { LatLng } from '../../../../../../shared/index';
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';
import { MapsHelpers } from '../../../../../../shared/helpers/maps.helpers';

@Component({
    templateUrl: 'edit-locations-list.component.html',
})
export class EditLocationsListComponent implements OnInit {

    locations: LocationSummary[] = [];
    deleteLocations: LocationSummary[]=[];
    project: ProjectSummary;
    viewNewLocation: Location;
    newLocation: Location;
    draggingToDelete: boolean;
    markerLocations: LocationSummary[] = [];
    bounds: any;

    constructor(
        private _locationHttpService: LocationHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private dragulaService: DragulaService
    ) {
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
            this.locations = data.locations;
            this.setBounds();
            this.project = data.project;
            this.resetNewLocation();
        });
    }

    resetNewLocation(){
        this.viewNewLocation = new Location();
        this.viewNewLocation.projectId = this.project.id;
        this.newLocation = null;
    }

    getLocations() {
        this._loadingWrapperService.Load(
            this._locationHttpService.getAll(this.project.id),
            (data) => this.locations = data
        );
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

    public remove(location: LocationSummary){
        if(this._dialogService.confirm(`Are you sure you want to remove location ${location.name}?`)){
            let loadingId = this._loadingService.startLoading();

            this._locationHttpService.delete(location.id).then(data=> {
                if (typeof(data)== 'string') {
                    this._dialogService.error(data);
                    this.getLocations();
                }else {
                    this._dialogService.success('The location was successfully removed');
                }
            }).catch()
            .then(() => this._loadingService.endLoading(loadingId));
        }else {
            this.getLocations();
        }
    }

    public setBounds(){
        this.markerLocations = this.locations.filter(l=> l.latLng.hasLatLng);
        if(this.markerLocations.length){
            this.bounds = MapsHelpers.getBounds(this.markerLocations.map((location)=> location.latLng));
        }
    }

    private onLocationDrag(args) {
        let draggedElement = args[0];
        if(draggedElement && HtmlClassHelpers.hasClass(draggedElement, 'can-delete'))
            this.draggingToDelete = true;
    }
    private onLocationDragEnd() {
        this.draggingToDelete = false;
    }
    private onLocationDrop(args) {

        // Delete if necessary
        if(this.deleteLocations.length > 0)
            this.remove(this.deleteLocations.splice(0, 1)[0]);
    }
    
    private onOver(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.addClass(el, 'hovering');
    }

    private onOut(args) {
        let [e, el, container] = args;
        HtmlClassHelpers.removeClass(el, 'hovering');
    }
}