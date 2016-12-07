import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectService } from '../../service/project.service';
import { ProjectSummary } from '../../model/project-summary.model';
import { LoadingService } from '../../../loading/service/loading.service';
import { DialogService } from '../../../shared/service/dialog.service';

@Component({
    templateUrl: 'projects-list.component.html',
})
export class ProjectsListComponent extends OnInit {

    projects: ProjectSummary[] = [];

    constructor(
        private _projectService: ProjectService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ) {
        super();
    }

    ngOnInit() {
        this._route.data.subscribe((data: { projects: ProjectSummary[] }) => {
            this.projects = data.projects;
        });
    }

    getProjects(){
        
        let loadingId = this._loadingService.startLoading();

        this._projectService.getAll().then(data => {
            this.projects = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    remove(project: ProjectSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove ${project.title}`)){

            let loadingId = this._loadingService.startLoading();

            this._projectService.delete(project.id).then(data=>{
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