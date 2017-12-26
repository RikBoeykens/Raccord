import { FullScriptUpload } from "../../model/full-script-upload.model";
import { Component } from "@angular/core";
import { ProjectSummary } from "../../../../index";
import { ActivatedRoute } from "@angular/router";

@Component({
  templateUrl: 'script-upload-landing.component.html',
})
export class ScriptUploadLandingComponent {

  scriptUpload: FullScriptUpload;
  project: ProjectSummary;

  constructor(
      private _route: ActivatedRoute
  ){
  }

  ngOnInit() {
      this._route.data.subscribe((data: { scriptUpload: FullScriptUpload, project: ProjectSummary }) => {
          this.scriptUpload = data.scriptUpload;
          this.project = data.project;
      });
  }
}