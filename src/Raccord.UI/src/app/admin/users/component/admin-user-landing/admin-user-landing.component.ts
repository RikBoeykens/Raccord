import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminUserHttpService } from '../../service/admin-user-http.service';
import { FullUser } from '../../model/full-user.model';
import { Project } from "../../../../projects/index";
import { LoadingService } from "../../../../loading/service/loading.service";
import { DialogService } from "../../../../shared/service/dialog.service";
import { ProjectUserProject } from '../../../project-users/model/project-user-project.model';
import { AdminProjectUserHttpService } from '../../../index';
import { ProjectUser } from '../../../project-users/model/project-user.model';
import { ProjectRole } from "../../../project-roles/model/project-role.model";
import { LoadingWrapperService } from '../../../../shared/service/loading-wrapper.service';

@Component({
    templateUrl: 'admin-user-landing.component.html',
})
export class AdminUserLandingComponent {

    user: FullUser;
    projects: ProjectUserProject[] = [];
    availableRoles: ProjectRole[] = [];
    chosenRoleId: number;
    searchProject: Project;

    constructor(
        private _projectHttpService: AdminUserHttpService,
        private _projectUserHttpService: AdminProjectUserHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private route: ActivatedRoute,
        private router: Router
    ){
    }

    ngOnInit() {
        this.route.data.subscribe((data: { user: FullUser, projects: ProjectUserProject[], projectRoles: ProjectRole[] }) => {
            this.user = data.user;
            this.projects = data.projects;
            this.availableRoles = data.projectRoles;
        });
        this.resetSearchProject();
    }

    public resetSearchProject() {
        this.searchProject = new Project();
    }

    public getProjects() {
        this._loadingWrapperService.Load(
            this._projectUserHttpService.getProjects(this.user.id),
            (data) => this.projects = data
        );
    }

    public addProject() {
        let loadingId = this._loadingService.startLoading();

        let newProjectUser = new ProjectUser();
        newProjectUser.projectID = this.searchProject.id;
        newProjectUser.userID = this.user.id;
        if (this.chosenRoleId) {
            newProjectUser.roleID = this.chosenRoleId;
        }
        this._projectUserHttpService.post(newProjectUser).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.resetSearchProject();
                this._dialogService.success("Successfully added project.");
                this.getProjects();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeProject(projectUser: ProjectUserProject){
        let loadingId = this._loadingService.startLoading();

        this._projectUserHttpService.delete(projectUser.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this._dialogService.success("Successfully removed project.");
                this.getProjects();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}