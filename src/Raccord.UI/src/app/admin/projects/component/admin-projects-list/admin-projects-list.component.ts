import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminProjectHttpService } from '../../service/admin-project-http.service';
import { ProjectSummary } from '../../../../projects';
import { LoadingService } from '../../../../loading/service/loading.service';
import { DialogService } from '../../../../shared/service/dialog.service';
import { Image } from '../../children/images/model/image.model';
import { LoadingWrapperService } from '../../../../shared/service/loading-wrapper.service';

@Component({
    templateUrl: 'admin-projects-list.component.html',
})
export class AdminProjectsListComponent implements OnInit {

    projects: ProjectSummary[] = [];

    constructor(
        private _adminProjectHttpService: AdminProjectHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { projects: ProjectSummary[] }) => {
            this.projects = data.projects;
        });
    }

    getProjects(){
        this._loadingWrapperService.Load(
            this._adminProjectHttpService.getAll(),
            (data) => this.projects = data
        );
    }

    remove(project: ProjectSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove ${project.title}`)){

            let loadingId = this._loadingService.startLoading();

            this._adminProjectHttpService.delete(project.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                }else{
                    this._dialogService.success('The project was successfully removed');
                    this.getProjects();
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }

    }
}