import { SceneSummary } from '../../../../../../../../shared/children/scenes';
import { SceneIntro, TimeOfDay } from '../../../../../../../../shared/children/sceneproperties';
import { ScriptLocation } from '../../../../../../../../shared/children/script-locations';
import { Image } from '../../../../../../../../shared/children/images';

export class ShootingDaySceneSummary extends SceneSummary {
  public linkID: number;
  public scheduledPageLength: number;

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
      projectId: number,
      primaryImage: Image,
      linkID: number,
      scheduledPageLength: number
    }
  ) {
    super(obj);
    if (obj) {
      this.linkID = obj.linkID;
      this.scheduledPageLength = obj.scheduledPageLength;
    }
  }
}
