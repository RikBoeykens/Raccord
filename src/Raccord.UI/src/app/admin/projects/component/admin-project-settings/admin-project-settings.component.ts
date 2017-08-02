import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminProjectHttpService } from '../../service/admin-project-http.service';
import { FullProject } from '../../../../projects';
import { LoadingService } from '../../../../loading/service/loading.service';
import { CanComponentDeactivate } from '../../../../shared/interface/can-component-deactivate.interface';
import { DialogService } from '../../../../shared/service/dialog.service';

@Component({
    templateUrl: 'admin-project-settings.component.html'
})
export class AdminProjectSettingsComponent implements CanComponentDeactivate {

    viewProject: FullProject;
    project: FullProject;

    constructor(
        private _projectHttpService: AdminProjectHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { project: FullProject }) => {
            this.project = data.project;
            this.viewProject = new FullProject(data.project);
        });
    }

    updateProject() {
        
        let loadingId = this._loadingService.startLoading();

        this.project = this.viewProject;

        this._projectHttpService.post(this.project).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this._router.navigate([`/admin/projects/${this.project.id}`]);
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