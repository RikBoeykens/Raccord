import { BaseModel } from "../../../../shared/model/base.model";

export class SceneFilterRequest extends BaseModel {
  projectID: number;
  searchText: string;
  minPageLength?: number;
  maxPageLength?: number;
  intExtIDs: number[] = [];
  scriptLocationIDs: number[] = [];
  dayNightIDs: number[] = [];
  locationSetIDs: number[] = [];
  locationIDs: number[] = [];
  characterIDs: number[] = [];
  breakdownItemIDs: number[] = [];
  scheduleDayIDs: number[] = [];
  scheduleSceneShootingDayIDs: number[] = [];
  callsheetIDs: number[] = [];
  callsheetSceneShootingDayIDs: number[] = [];
  shootingDayIDs: number[] = [];

  constructor(
    obj?:{
      projectID: number,
      searchText: string,
      minPageLength?: number,
      maxPageLength?: number,
      intExtIDs: number[],
      scriptLocationIDs: number[],
      dayNightIDs: number[],
      locationSetIDs: number[],
      locationIDs: number[],
      characterIDs: number[],
      breakdownItemIDs: number[],
      scheduleDayIDs: number[],
      scheduleSceneShootingDayIDs: number[],
      callsheetIDs: number[],
      callsheetSceneShootingDayIDs: number[],
      shootingDayIDs: number[]
    }
  ){
    super();
    if (obj) {
      this.projectID = obj.projectID;
      this.searchText = obj.searchText;
      this.minPageLength = obj.minPageLength;
      this.maxPageLength = obj.maxPageLength;
      this.intExtIDs = obj.intExtIDs;
      this.scriptLocationIDs = obj.scriptLocationIDs;
      this.dayNightIDs = obj.dayNightIDs;
      this.locationSetIDs = obj.locationSetIDs;
      this.locationIDs = obj.locationIDs;
      this.characterIDs = obj.characterIDs;
      this.breakdownItemIDs = obj.breakdownItemIDs;
      this.scheduleDayIDs = obj.scheduleDayIDs;
      this.scheduleSceneShootingDayIDs = obj.scheduleSceneShootingDayIDs;
      this.callsheetIDs = obj.callsheetIDs;
      this.callsheetSceneShootingDayIDs = obj.callsheetSceneShootingDayIDs;
      this.shootingDayIDs = obj.shootingDayIDs;
    }
  }
}