import { BaseModel } from '../../../../../../shared';

export class SceneFilterRequest extends BaseModel {
  public projectID: number;
  public searchText: string;
  public minPageLength?: number;
  public maxPageLength?: number;
  public sceneIntroIDs: number[] = [];
  public scriptLocationIDs: number[] = [];
  public timeOfDayIDs: number[] = [];
  public locationSetIDs: number[] = [];
  public locationIDs: number[] = [];
  public characterIDs: number[] = [];
  public castMemberIDs: number[] = [];
  public breakdownItemIDs: number[] = [];
  public scheduleDayIDs: number[] = [];
  public scheduleSceneShootingDayIDs: number[] = [];
  public callsheetIDs: number[] = [];
  public callsheetSceneShootingDayIDs: number[] = [];
  public shootingDayIDs: number[] = [];

  constructor(
    obj?: {
      projectID: number,
      searchText: string,
      minPageLength?: number,
      maxPageLength?: number,
      sceneIntroIDs: number[],
      scriptLocationIDs: number[],
      timeOfDayIDs: number[],
      locationSetIDs: number[],
      locationIDs: number[],
      characterIDs: number[],
      castMemberIDs: number[],
      breakdownItemIDs: number[],
      scheduleDayIDs: number[],
      scheduleSceneShootingDayIDs: number[],
      callsheetIDs: number[],
      callsheetSceneShootingDayIDs: number[],
      shootingDayIDs: number[]
    }
  ) {
    super();
    if (obj) {
      this.projectID = obj.projectID;
      this.searchText = obj.searchText;
      this.minPageLength = obj.minPageLength;
      this.maxPageLength = obj.maxPageLength;
      this.sceneIntroIDs = obj.sceneIntroIDs;
      this.scriptLocationIDs = obj.scriptLocationIDs;
      this.timeOfDayIDs = obj.timeOfDayIDs;
      this.locationSetIDs = obj.locationSetIDs;
      this.locationIDs = obj.locationIDs;
      this.characterIDs = obj.characterIDs;
      this.castMemberIDs = obj.castMemberIDs;
      this.breakdownItemIDs = obj.breakdownItemIDs;
      this.scheduleDayIDs = obj.scheduleDayIDs;
      this.scheduleSceneShootingDayIDs = obj.scheduleSceneShootingDayIDs;
      this.callsheetIDs = obj.callsheetIDs;
      this.callsheetSceneShootingDayIDs = obj.callsheetSceneShootingDayIDs;
      this.shootingDayIDs = obj.shootingDayIDs;
    }
  }
}
