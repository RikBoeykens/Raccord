import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectService } from '../../service/project.service';
import { ProjectSummary } from '../../model/project-summary.model';
import { LoadingService } from '../../../loading/service/loading.service';
import { CanComponentDeactivate } from '../../../shared/interface/can-component-deactivate.interface';
import { DialogService } from '../../../shared/service/dialog.service';

@Component({
    templateUrl: 'add-project.component.html'
})
export class AddProjectComponent implements CanComponentDeactivate {

    viewProject: ProjectSummary;
    project: ProjectSummary;

    constructor(
        private _projectService: ProjectService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _router: Router
    ){
        this.viewProject = new ProjectSummary();
    }

    addProject() {

        let loadingId = this._loadingService.startLoading();

        this.project = this.viewProject;

        this._projectService.post(this.project).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this._router.navigate(['/projects', data]);
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    canDeactivate(){
        if(!this.viewProject.title || this.viewProject.equals(this.project))
            return true;

        return this._dialogService.confirm('All data will be lost by navigating away');
    }
}