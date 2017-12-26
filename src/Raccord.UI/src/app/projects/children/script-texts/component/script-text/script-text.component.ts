import { Component } from "@angular/core";
import { ProjectSummary } from "../../../../index";
import { ActivatedRoute } from "@angular/router";
import { SceneText } from "../../model/scene-text.model";
import { BaseSceneComponent } from "../../model/base-scene-component.model";

@Component({
  templateUrl: 'script-text.component.html',
})
export class ScriptTextComponent {

  sceneTexts: SceneText[];
  project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ){
  }

  ngOnInit() {
      this._route.data.subscribe((data: { sceneTexts: SceneText[], project: ProjectSummary }) => {
        this.sceneTexts = data.sceneTexts;
        this.project = data.project;
      });

  }

  public getSceneComponents(scene: SceneText) {
    return (<BaseSceneComponent[]> scene.actions).concat(scene.dialogues)
      .sort((a: BaseSceneComponent, b: BaseSceneComponent) => a.order - b.order);
  }
}