import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminProjectHttpService } from '../../service/admin-project-http.service';
import { FullProject } from '../../../../projects';
import { CrewUserUser } from "../../../crew/model/crew-user-user.model";
import { AdminCrewHttpService } from "../../../crew/service/admin-crew-http.service";
import { LoadingService } from "../../../../loading/service/loading.service";
import { DialogService } from "../../../../shared/service/dialog.service";

@Component({
    templateUrl: 'admin-project-landing.component.html',
})
export class AdminProjectLandingComponent {

    project: FullProject;
    crew: CrewUserUser[] = [];

    constructor(
        private _projectHttpService: AdminProjectHttpService,
        private _crewHttpService: AdminCrewHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private route: ActivatedRoute,
        private router: Router
    ){
    }

    ngOnInit() {
        this.route.data.subscribe((data: { project: FullProject, crew: CrewUserUser[] }) => {
            this.project = data.project;
            this.crew = data.crew;
        });
    }

    getCrewMembers(){
        let loadingId = this._loadingService.startLoading();

        this._crewHttpService.getUsers(this.project.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.crew = data;
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeCrewMember(crewUser: CrewUserUser){
        let loadingId = this._loadingService.startLoading();

        this._crewHttpService.delete(crewUser.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this._dialogService.success("Successfully removed crew member.");
                this.getCrewMembers();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}