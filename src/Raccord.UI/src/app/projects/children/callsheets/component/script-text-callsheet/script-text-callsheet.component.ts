import { Component } from "@angular/core";
import { ProjectSummary } from "../../../../index";
import { ActivatedRoute } from "@angular/router";
import { SceneText } from "../../../script-texts/model/scene-text.model";
import { BaseSceneComponent } from "../../../script-texts/model/base-scene-component.model";
import { CallsheetSummary } from "../../model/callsheet-summary.model";

@Component({
  templateUrl: 'script-text-callsheet.component.html',
})
export class ScriptTextCallsheetComponent {

  sceneTexts: SceneText[];
  callsheet: CallsheetSummary;
  project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ){
  }

  ngOnInit() {
      this._route.data.subscribe((data: { sceneTexts: SceneText[], project: ProjectSummary, callsheet: CallsheetSummary }) => {
        this.sceneTexts = data.sceneTexts;
        this.project = data.project;
        this.callsheet = data.callsheet;
      });
  }
}