import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { FullScriptUpload } from "../model/full-script-upload.model";
import { ScriptUploadHttpService } from "./script-upload-http.service";

@Injectable()
export class ScriptUploadResolve implements Resolve<FullScriptUpload> {

  constructor(
      private scriptLocationHttpService: ScriptUploadHttpService, 
      private router: Router
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    let scriptUploadId = route.params['scriptUploadId'];

    return this.scriptLocationHttpService.get(scriptUploadId).then(scriptUpload => {
        if (scriptUpload) {
            return scriptUpload;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}