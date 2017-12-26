import { Scene } from "../../scenes/model/scene.model";
import { SceneAction } from "./scene-action.model";
import { SceneDialogue } from "./scene-dialogue.model";
import { BaseSceneComponent } from "./base-scene-component.model";

export class SceneText{
  scene: Scene;
  actions: SceneAction[];
  dialogues: SceneDialogue[];

  constructor(obj?: {
                    scene: Scene,
                    actions: SceneAction[],
                    dialogues: SceneDialogue[]
                  }){
    if(obj){
        this.scene = obj.scene;
        this.actions = obj.actions;
        this.dialogues = obj.dialogues;
    }
  }
}