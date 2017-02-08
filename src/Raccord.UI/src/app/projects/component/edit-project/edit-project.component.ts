import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectHttpService } from '../../service/project-http.service';
import { ProjectSummary } from '../../model/project-summary.model';
import { LoadingService } from '../../../loading/service/loading.service';
import { CanComponentDeactivate } from '../../../shared/interface/can-component-deactivate.interface';
import { DialogService } from '../../../shared/service/dialog.service';

@Component({
    templateUrl: 'edit-project.component.html'
})
export class EditProjectComponent implements CanComponentDeactivate {

    viewProject: ProjectSummary;
    project: ProjectSummary;

    constructor(
        private _projectHttpService: ProjectHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: ProjectSummary }) => {
            this.project = data.project;
            this.viewProject = new ProjectSummary(data.project);
        });
    }

    updateProject() {
        
        let loadingId = this._loadingService.startLoading();

        this.project = this.viewProject;

        this._projectHttpService.post(this.project).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this._router.navigate(['/projects']);
            }
        }).catch()
        .then(()=> this._loadingService.endLoading(loadingId));
    }

    canDeactivate(){
        if(this.viewProject.equals(this.project))
            return true;

        return this._dialogService.confirm('All data will be lost by navigating away');
    }
}