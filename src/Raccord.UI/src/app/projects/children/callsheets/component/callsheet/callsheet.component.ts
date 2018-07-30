import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProjectSummary } from '../../../../../shared/children/projects';
import {
  FullCallsheet,
  CallsheetLocationSet,
  CallsheetSceneScene,
  Location,
  CallsheetCharacterCharacter,
  CallsheetLocation
} from '../../../..';
import { ProjectHelpers } from '../../../../../shared/children/projects/helpers/project.helpers';
import { CastMember } from '../../../../../shared/children/cast';
import { RouteSettings } from '../../../../../shared';

@Component({
  templateUrl: 'callsheet.component.html',
})
export class CallsheetComponent implements OnInit {
  public project: ProjectSummary;
  public callsheet: FullCallsheet;

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

  public getCrewUnitLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.project.id}/${RouteSettings.CALLSHEETS}/${this.callsheet.crewUnit.id}`;
  }
}
