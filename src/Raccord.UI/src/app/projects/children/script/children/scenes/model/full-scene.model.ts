import { Scene } from '../../../../../../shared/children/scenes/model/scene.model';
import { LinkedImage } from '../../../../../../shared/children/images';
import { LinkedCharacter } from '../../../../../../shared/children/characters';
import { SceneIntro, TimeOfDay } from '../../../../../../shared/children/sceneproperties';
import { ScriptLocation } from '../../../../../../shared/children/script-locations';
import { SceneBreakdown, ShootingDayInfo, Comment } from '../../../../..';

export class FullScene extends Scene {
  public images: LinkedImage[];
  public characters: LinkedCharacter[];
  public breakdownInfo: SceneBreakdown;
  public shootingDays: ShootingDayInfo[];
  public comments: Comment[];

  constructor(obj?: {
                      id: number,
                      number: string,
                      summary: string,
                      pageLength: number,
                      timing: string,
                      sceneIntro: SceneIntro,
                      scriptLocation: ScriptLocation,
                      timeOfDay: TimeOfDay,
                      projectId: number,
                      images: LinkedImage[],
                      characters: LinkedCharacter[],
                      breakdownInfo: SceneBreakdown,
                      shootingDays: ShootingDayInfo[],
                      comments: Comment[]
                  }) {
      super(obj);
      if (obj) {
          this.images = obj.images;
          this.characters = obj.characters;
          this.breakdownInfo = obj.breakdownInfo;
          this.shootingDays = obj.shootingDays;
          this.comments = obj.comments;
      }
  }
}
