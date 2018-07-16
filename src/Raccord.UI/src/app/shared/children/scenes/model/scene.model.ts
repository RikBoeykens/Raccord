import { BaseModel } from '../../../model/base.model';
import { SceneIntro, TimeOfDay } from '../../sceneproperties';
import { ScriptLocation } from '../../script-locations';

export class Scene extends BaseModel {
  public id: number;
  public number: string;
  public summary: string;
  public pageLength: number;
  public timing: string;
  public sceneIntro: SceneIntro;
  public scriptLocation: ScriptLocation;
  public timeOfDay: TimeOfDay;
  public projectId: number;

  constructor(
    obj?: {
      id: number,
      number: string,
      summary: string,
      pageLength: number,
      timing: string,
      sceneIntro: SceneIntro,
      scriptLocation: ScriptLocation,
      timeOfDay: TimeOfDay,
      projectId: number
    }
  ) {
    super();
    if (obj) {
      this.id = obj.id;
      this.number = obj.number;
      this.summary = obj.summary;
      this.pageLength = obj.pageLength;
      this.timing = obj.timing;
      this.sceneIntro = obj.sceneIntro;
      this.scriptLocation = obj.scriptLocation;
      this.timeOfDay = obj.timeOfDay;
      this.projectId = obj.projectId;
    } else {
      this.id = 0;
    }
  }
}
