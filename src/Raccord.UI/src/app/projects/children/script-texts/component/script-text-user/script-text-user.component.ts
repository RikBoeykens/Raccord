import { Component, OnInit } from '@angular/core';
import { ProjectSummary } from '../../../../index';
import { ActivatedRoute } from '@angular/router';
import { SceneText } from '../../model/scene-text.model';
import { BaseSceneComponent } from '../../model/base-scene-component.model';

@Component({
  templateUrl: 'script-text-user.component.html',
})
export class ScriptTextUserComponent implements OnInit {

  public sceneTexts: SceneText[];
  public project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ){
  }

  public ngOnInit() {
      this._route.data.subscribe((data: { sceneTexts: SceneText[], project: ProjectSummary }) => {
        this.sceneTexts = data.sceneTexts;
        this.project = data.project;
      });

  }
}