import { Component, Input } from '@angular/core';
import { RouteSettings } from '../../../../../../../shared';
import { CallsheetSceneScene } from '../../../../../..';
import { Character } from '../../../../../../../shared/children/characters';

@Component({
  selector: 'callsheet-scenes-table',
  templateUrl: 'callsheet-scenes-table.component.html',
})
export class CallsheetScenesTableComponent {
  @Input() public callsheetScenes: CallsheetSceneScene[];
  @Input() public projectId: number;

  public displayedColumns = [
    'image', 'description', 'number', 'timeofday', 'pagelength', 'characters', 'location', 'sides'
  ];

  public getScriptLocationLink(callsheetScene: CallsheetSceneScene): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.SCRIPTLOCATIONS}/${callsheetScene.scene.scriptLocation.id}`;
  }

  public getSceneLink(callsheetScene: CallsheetSceneScene): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.SCENES}/${callsheetScene.scene.id}`;
  }

  public getCharacterLink(character: Character): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.CHARACTERS}/${character.id}`;
  }

  public getLocationSetLink(callsheetScene: CallsheetSceneScene): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONS}/${callsheetScene.locationSet.id}`;
  }

  public getLocationLink(callsheetScene: CallsheetSceneScene): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONS}/${callsheetScene.locationSet.location.id}`;
  }

  public getSidesLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.SCRIPTTEXT}`;
  }
}
