import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProjectSummary } from '../../../../../shared/children/projects';
import {
  FullCallsheet,
  CallsheetLocation,
  CallsheetLocationSet,
  CallsheetSceneScene,
  Location,
  CallsheetCharacterCharacter
} from '../../../..';
import { ProjectHelpers } from '../../../../../shared/children/projects/helpers/project.helpers';
import { CastMember } from '../../../../../shared/children/cast';
import { MapsHelpers } from '../../../../../shared';

@Component({
  templateUrl: 'callsheet.component.html',
})
export class CallsheetComponent implements OnInit {
  public project: ProjectSummary;
  public callsheet: FullCallsheet;
  public bounds: any;
  public markerLocations: CallsheetLocation[] = [];
  public markerLocationSets: CallsheetLocationSet[] = [];

  constructor(
      private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: {
      callsheet: FullCallsheet
    }) => {
      this.project = ProjectHelpers.getCurrentProject();
      this.callsheet = data.callsheet;
      this.setBounds();
    });
  }

  public getLocations() {
    const locations: Location[] = [];
    this.callsheet.scenes.forEach((scene: CallsheetSceneScene) => {
      const currentSceneLocation = scene.locationSet.id !== 0 ?
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
        this.markerLocationSets =
            this.markerLocationSets.concat(location.sets.filter((l) => l.latLng.hasLatLng));
      });
      if (this.markerLocations.length || this.markerLocationSets.length) {
        let latLngs = this.markerLocations.map((location) => location.latLng);
        latLngs =
            latLngs.concat(this.markerLocationSets.map((locationSet) => locationSet.latLng));
        this.bounds = MapsHelpers.getBounds(latLngs);
      }
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
