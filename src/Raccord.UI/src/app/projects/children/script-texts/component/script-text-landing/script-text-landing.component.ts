import { Component } from "@angular/core";
import { ProjectSummary } from "../../../../index";
import { ActivatedRoute } from "@angular/router";
import { SceneText } from "../../model/scene-text.model";
import { BaseSceneComponent } from "../../model/base-scene-component.model";

@Component({
  templateUrl: 'script-text-landing.component.html',
})
export class ScriptTextLandingComponent {

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
}