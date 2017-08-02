import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AdminProjectHttpService } from '../../service/admin-project-http.service';
import { Project } from '../../../../projects';
import { LoadingService } from '../../../../loading/service/loading.service';
import { CanComponentDeactivate } from '../../../../shared/interface/can-component-deactivate.interface';
import { DialogService } from '../../../../shared/service/dialog.service';

@Component({
    templateUrl: 'admin-add-project.component.html'
})
export class AdminAddProjectComponent implements CanComponentDeactivate {

    viewProject: Project;
    project: Project;

    constructor(
        private _projectHttpService: AdminProjectHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _router: Router
    ){
        this.viewProject = new Project();
    }

    addProject() {

        let loadingId = this._loadingService.startLoading();

        this.project = this.viewProject;

        this._projectHttpService.post(this.project).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this._router.navigate(['/admin/projects', data]);
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    canDeactivate(){
        if(!this.viewProject.title.length)
            return true;

        return this._dialogService.confirm('All data will be lost by navigating away');
    }
}