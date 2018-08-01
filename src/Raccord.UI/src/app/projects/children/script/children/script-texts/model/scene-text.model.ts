import { SceneAction } from './scene-action.model';
import { SceneDialogue } from './scene-dialogue.model';
import { Scene } from '../../../../../../shared/children/scenes';

export class SceneText {
  public scene: Scene;
  public actions: SceneAction[];
  public dialogues: SceneDialogue[];

  constructor(obj?: {
                    scene: Scene,
                    actions: SceneAction[],
                    dialogues: SceneDialogue[]
                  }) {
    if (obj) {
        this.scene = obj.scene;
        this.actions = obj.actions;
        this.dialogues = obj.dialogues;
    }
  }
}
