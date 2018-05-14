import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { FullCallsheet, CallsheetCharacterCharacter } from "../../";
import { CallsheetSceneScene } from "../../";
import { Location } from "../../../locations/locations/model/location.model";
import { CallsheetLocation } from '../../../locations/locations/model/callsheet-location.model';
import { MapsHelpers } from '../../../../../shared/helpers/maps.helpers';
import { CallsheetLocationSet } from '../../../locations/location-sets/model/callsheet-location-set.model';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from '../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { CastMember } from '../../../cast/model/cast-member.model';

@Component({
    templateUrl: 'callsheet.component.html',
})
export class CallsheetComponent implements OnInit {

    project: ProjectSummary;
    callsheet: FullCallsheet;
    bounds: any;
    markerLocations: CallsheetLocation[] = [];
    markerLocationSets: CallsheetLocationSet[] = [];

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            project: ProjectSummary,
            callsheet: FullCallsheet
        }) => {
            this.project = data.project;
            this.callsheet = data.callsheet;
            this.setBounds();
        });
    }

    public getLocations() {
        let locations: Location[] = [];
        this.callsheet.scenes.forEach((scene: CallsheetSceneScene) => {
            let currentSceneLocation = scene.locationSet.id !== 0 ?
                scene.locationSet.location : null;
            if (currentSceneLocation &&
                (locations.length === 0 ||
                    locations[locations.length - 1].id !== currentSceneLocation.id)) {
                locations.push(currentSceneLocation);
            }
        });
        return locations;
    }

    public setBounds() {
        this.markerLocations = this.callsheet.locations.filter((l) => l.latLng.hasLatLng);
        this.markerLocations.forEach((location) => {
            this.markerLocationSets = this.markerLocationSets.concat(location.sets);
        });
        if (this.markerLocations.length || this.markerLocationSets.length) {
            let latLngs = this.markerLocations.map((location)=> location.latLng);
            latLngs =
                latLngs.concat(this.markerLocationSets.map((locationSet) => locationSet.latLng));
            this.bounds = MapsHelpers.getBounds(latLngs);
        }
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canEditGeneral
        );
    }

    public showCharacterImage(callsheetCharacter: CallsheetCharacterCharacter) {
        return callsheetCharacter.castMember.id === 0 &&
        callsheetCharacter.character.primaryImage.id !== 0;
    }

    public showUserImage(callsheetCharacter: CallsheetCharacterCharacter) {
        return callsheetCharacter.castMember.id !== 0;
    }

    public getFullName(castMember: CastMember) {
        return `${castMember.firstName} ${castMember.lastName}`;
    }
}
