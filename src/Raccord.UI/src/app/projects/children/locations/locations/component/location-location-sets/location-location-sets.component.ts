import { Component, Input, OnInit } from '@angular/core';
import { LocationSetScriptLocation } from '../../..';
import { LocationSet } from '../../..';
import { LocationSetHttpService } from '../../../location-sets/service/location-set-http.service';
import { ScriptLocationHttpService } from '../../../../script-locations/service/script-location-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { SelectedEntity } from '../../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../../shared/enums/entity-type.enum';
import { AccountHelpers } from '../../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from '../../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';

@Component({
    selector: 'location-location-sets',
    templateUrl: 'location-location-sets.component.html'
})
export class LocationLocationSetsComponent {

    @Input() projectId: number;
    @Input() locationId: number;
    @Input() sets: LocationSetScriptLocation[];
    scriptLocationType: EntityType[] = [EntityType.scriptLocation];

    constructor(
        private _locationSetHttpService: LocationSetHttpService,
        private _scriptLocationHttpService: ScriptLocationHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    getSets(){
        this._loadingWrapperService.Load(
            this._locationSetHttpService.getScriptLocations(this.locationId),
            (data) => this.sets = data
        );
    }

    addSet(scriptLocation: SelectedEntity) {
        this._loadingWrapperService.Load(
            this._scriptLocationHttpService.get(scriptLocation.entityId),
            (data) => {
                let newSet = new LocationSet();
                newSet.locationId = this.locationId;
                newSet.scriptLocationId = scriptLocation.entityId;
                newSet.name = data.name;
                newSet.description = data.description;

                this._loadingWrapperService.Load(
                    this._locationSetHttpService.post(newSet),
                    () => this.getSets()
                )
            }
        );
    }

    remove(locationSet: LocationSetScriptLocation){
        let loadingId = this._loadingService.startLoading();

        this._locationSetHttpService.delete(locationSet.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getSets();
                this._dialogService.success("Successfully removed location set.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.projectId,
            ProjectPermissionEnum.canEditGeneral
        );
    }
}