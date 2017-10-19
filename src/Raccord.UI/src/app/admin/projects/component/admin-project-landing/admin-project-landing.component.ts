import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminProjectHttpService } from '../../service/admin-project-http.service';
import { FullProject } from '../../../../projects';
import { LoadingService } from "../../../../loading/service/loading.service";
import { DialogService } from "../../../../shared/service/dialog.service";
import { ProjectUserUser } from '../../../project-users/model/project-user-user.model';
import { AdminProjectUserHttpService } from '../../../index';

@Component({
    templateUrl: 'admin-project-landing.component.html',
})
export class AdminProjectLandingComponent {

    project: FullProject;
    projectUsers: ProjectUserUser[] = [];

    constructor(
        private _projectHttpService: AdminProjectHttpService,
        private _projectUserHttpService: AdminProjectUserHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private route: ActivatedRoute,
        private router: Router
    ){
    }

    ngOnInit() {
        this.route.data.subscribe((data: { project: FullProject, projectUsers: ProjectUserUser[] }) => {
            this.project = data.project;
            this.projectUsers = data.projectUsers;
        });
    }

    getProjectUsers(){
        let loadingId = this._loadingService.startLoading();

        this._projectUserHttpService.getUsers(this.project.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.projectUsers = data;
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeProjectUser(projectUser: ProjectUserUser){
        let loadingId = this._loadingService.startLoading();

        this._projectUserHttpService.delete(projectUser.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this._dialogService.success("Successfully removed project user.");
                this.getProjectUsers();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}