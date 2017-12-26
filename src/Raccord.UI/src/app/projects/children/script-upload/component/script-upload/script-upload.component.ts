import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ProjectSummary } from "../../../../index";
import { ScriptUploadHttpService } from "../../service/script-upload-http.service";
import { LoadingService } from "../../../../../loading/service/loading.service";
import { DialogService } from "../../../../../shared/service/dialog.service";

@Component({
  templateUrl: 'script-upload.component.html',
})
export class ScriptUploadComponent implements OnInit {

  project: ProjectSummary;

  constructor(
      private _scriptUploadService: ScriptUploadHttpService,
      private _loadingService: LoadingService,
      private _dialogService: DialogService,
      private _route: ActivatedRoute,
      private _router: Router
  ) {
  }

  ngOnInit() {
      this._route.data.subscribe((data: { project: ProjectSummary }) => {
          this.project = data.project;
      });
  }

  upload(fileInput: any){
    let loadingId = this._loadingService.startLoading();

    let files = <Array<File>>fileInput.target.files;

    this._scriptUploadService.upload(files, this.project.id).then(data=>{
        if(typeof(data)=='string'){
            this._dialogService.error(data);
        }else{
            fileInput.target.value = "";
            this._router.navigate(['projects', this.project.id, 'scriptuploads', data]);
        }
    }).catch()
    .then(()=>
        this._loadingService.endLoading(loadingId)
    );
  }
}