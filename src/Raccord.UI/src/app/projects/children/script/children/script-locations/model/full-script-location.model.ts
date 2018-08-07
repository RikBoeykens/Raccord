import { ScriptLocation } from '../../../../../../shared/children/script-locations';
import { SceneSummary } from '../../../../../../shared/children/scenes';
import { LinkedImage } from '../../../../../../shared/children/images';
import { LocationSetLocation, Comment } from '../../../../..';

export class FullScriptLocation extends ScriptLocation {
  public scenes: SceneSummary[];
  public images: LinkedImage[];
  public sets: LocationSetLocation[];
  public comments: Comment[];

  constructor(
    obj?: {
      id: number,
      name: string,
      description: string,
      projectID: number,
      scenes: SceneSummary[],
      images: LinkedImage[],
      sets: LocationSetLocation[],
      comments: Comment[]
  }) {
    super(obj);
    if (obj) {
      this.scenes = obj.scenes;
      this.images = obj.images;
      this.sets = obj.sets;
      this.comments = obj.comments;
    }
  }
}
