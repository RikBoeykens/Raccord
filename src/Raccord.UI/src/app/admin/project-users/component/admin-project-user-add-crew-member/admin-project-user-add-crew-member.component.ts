import { Component } from "@angular/core";
import { FullProjectUser } from "../../model/full-project-user.model";
import { AdminProjectUserHttpService } from "../../service/admin-project-user-http.service";
import { AdminProjectUserCrewHttpService } from "../../service/admin-project-user-crew-http.service";
import { LoadingService } from "../../../../loading/service/loading.service";
import { DialogService } from "../../../../shared/service/dialog.service";
import { ActivatedRoute, Router } from "@angular/router";
import { FullCrewDepartment } from "../../../../projects/children/crew/departments/model/full-crew-department.model";
import { OnInit } from "@angular/core/src/metadata/lifecycle_hooks";
import { CrewMemberSummary } from "../../../../projects/children/crew/crew-members/model/crew-member-summary.model";
import { CreateUserCrewMember } from "../../model/create-user-crew-member.model";

@Component({
  templateUrl: 'admin-project-user-add-crew-member.component.html',
})
export class AdminProjectUserAddCrewMemberComponent implements OnInit {

    projectUser: FullProjectUser;
    departments: FullCrewDepartment[];
    newCrewMember: CreateUserCrewMember;

    constructor(
        private _projectUserHttpService: AdminProjectUserHttpService,
        private _projectUserCrewHttpService: AdminProjectUserCrewHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private route: ActivatedRoute,
        private router: Router
    ){
    }

    public ngOnInit() {
        this.route.data.subscribe((data: { projectUser: FullProjectUser, departments: FullCrewDepartment[] }) => {
            this.projectUser = data.projectUser;
            this.departments = data.departments;
            this.newCrewMember = new CreateUserCrewMember();
            this.newCrewMember.projectUserId = this.projectUser.id;
            if(this.departments.length) {
                this.newCrewMember.departmentId = this.departments[0].id;
            }
        });
    }

    public getDepartments() {
        return this.departments.filter((department: FullCrewDepartment) => this.getCrew(department).length);
    }

    public getCrew(department: FullCrewDepartment) {
        return department.crewMembers.filter((crewMember: CrewMemberSummary) => crewMember.userID === '');
    }

    public addNewCrewMember() {
        let loadingId = this._loadingService.startLoading();

        this._projectUserCrewHttpService.post(this.newCrewMember).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.router.navigateByUrl(`/admin/projectusers/${this.projectUser.id}`);
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        ); 
    }

    public linkCrewMember(crewMember: CrewMemberSummary) {
        let loadingId = this._loadingService.startLoading();

        this._projectUserCrewHttpService.addLink(this.projectUser.id, crewMember.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.router.navigateByUrl(`/admin/projectusers/${this.projectUser.id}`);
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}