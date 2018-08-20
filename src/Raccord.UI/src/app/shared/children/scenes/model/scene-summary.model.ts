import { SceneIntro, TimeOfDay } from '../../sceneproperties';
import { ScriptLocation } from '../../script-locations';
import { Scene } from './scene.model';
import { Image } from '../../images';

export class SceneSummary extends Scene {
  public primaryImage: Image;

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
      primaryImage: Image
    }
  ) {
    super(obj);
    if (obj) {
      this.primaryImage = obj.primaryImage;
    }
  }
}
