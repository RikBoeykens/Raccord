import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminUserHttpService } from '../../service/admin-user-http.service';
import { FullUser } from '../../model/full-user.model';
import { CrewUserProject } from "../../../crew/model/crew-user-project.model";
import { AdminCrewHttpService } from "../../../crew/service/admin-crew-http.service";
import { Project } from "../../../../projects/index";
import { LoadingService } from "../../../../loading/service/loading.service";
import { DialogService } from "../../../../shared/service/dialog.service";
import { CrewUser } from "../../../crew/model/crew-user.model";

@Component({
    templateUrl: 'admin-user-landing.component.html',
})
export class AdminUserLandingComponent {

    user: FullUser;
    projects: CrewUserProject[] = [];
    searchProject: Project;

    constructor(
        private _projectHttpService: AdminUserHttpService,
        private _crewHttpService: AdminCrewHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private route: ActivatedRoute,
        private router: Router
    ){
    }

    ngOnInit() {
        this.route.data.subscribe((data: { user: FullUser, projects: CrewUserProject[] }) => {
            this.user = data.user;
            this.projects = data.projects;
        });
        this.resetSearchProject();
    }

    resetSearchProject(){
        this.searchProject = new Project();
    }

    addProject(){
        let loadingId = this._loadingService.startLoading();

        let newCrewUser = new CrewUser();
        newCrewUser.projectID = this.searchProject.id;
        newCrewUser.userID = this.user.id;
        this._crewHttpService.post(newCrewUser).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.resetSearchProject();
                this._dialogService.success("Successfully added crew member.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}