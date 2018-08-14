import { Component, Input } from '@angular/core';
import { ScheduleSceneScene } from '../../../../../../../..';
import { Scene } from '../../../../../../../../../shared/children/scenes';
import { LinkedCharacter } from '../../../../../../../../../shared/children/characters';
import { RouteSettings } from '../../../../../../../../../shared';

@Component({
  selector: 'schedule-scenes-table',
  templateUrl: 'schedule-scenes-table.component.html',
})
export class ScheduleScenesTableComponent {
  @Input() public scheduleScenes: ScheduleSceneScene[];
  @Input() public projectId: number;
  public displayedColumns = [
    'scene',
    'characters',
    'location'
  ];

  public getSceneLink(scheduleScene: ScheduleSceneScene) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.SCENES}/${scheduleScene.scene.id}`;
  }

  public getCharacterLink(character: LinkedCharacter) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.CHARACTERS}/${character.id}`;
  }

  public getLocationLink(scheduleScene: ScheduleSceneScene) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONS}/${scheduleScene.locationSet.location.id}`;
  }

  public getLocationSetLink(scheduleScene: ScheduleSceneScene) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONSETS}/${scheduleScene.locationSet.id}`;
  }
}
