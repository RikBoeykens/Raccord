import { Component, OnInit } from "@angular/core";
import { FullProjectUser } from "../../model/full-project-user.model";
import { AdminProjectUserHttpService } from "../../service/admin-project-user-http.service";
import { AdminProjectUserCrewHttpService } from "../../service/admin-project-user-crew-http.service";
import { LoadingService } from "../../../../loading/service/loading.service";
import { DialogService } from "../../../../shared/service/dialog.service";
import { ActivatedRoute } from "@angular/router";
import { CrewMemberSummary } from "../../../../projects/children/crew/crew-members/model/crew-member-summary.model";
import { CrewMember } from "../../../../projects/children/crew/crew-members/model/crew-member.model";
import { CrewMemberHttpService } from "../../../../projects/children/crew/crew-members/service/crew-member-http.service";
import { MdDialog } from "@angular/material";
import { AdminEditCrewMemberDialog } from "../admin-edit-crew-member-dialog/admin-edit-crew-member-dialog.component";
import { ProjectRole } from "../../../project-roles/model/project-role.model";
import { ProjectUser } from "../../model/project-user.model";

@Component({
  templateUrl: 'admin-project-user-landing.component.html',
})
export class AdminProjectUserLandingComponent implements OnInit  {

  projectUser: FullProjectUser;
  projectRoles: ProjectRole[];

  constructor(
      private _projectUserHttpService: AdminProjectUserHttpService,
      private _projectUserCrewHttpService: AdminProjectUserCrewHttpService,
      private _crewMemberHttpService: CrewMemberHttpService,
      private _loadingService: LoadingService,
      private _dialogService: DialogService,
      private route: ActivatedRoute,
      private _dialog: MdDialog
  ){
  }

  ngOnInit() {
      this.route.data.subscribe((data: { projectUser: FullProjectUser, projectRoles: ProjectRole[] }) => {
          this.projectUser = data.projectUser;
          this.projectRoles = data.projectRoles;
      });
  }

  public getProjectUser() {
    let loadingId = this._loadingService.startLoading();

    this._projectUserHttpService.get(this.projectUser.id).then(data=>{
        if(typeof(data)=='string'){
            this._dialogService.error(data);
        }else{
            this.projectUser = data;
        }
    }).catch()
    .then(()=>
        this._loadingService.endLoading(loadingId)
    );
  }

  public updateProjectUser() {
    let loadingId = this._loadingService.startLoading();
    let toUpdate = new ProjectUser({ 
        id: this.projectUser.id, 
        projectID: this.projectUser.project.id,
        userID: this.projectUser.user.id,
        roleID: this.projectUser.projectRole !== null ?
                    this.projectUser.projectRole.id !== 0 ?
                        this.projectUser.projectRole.id : null : null
    });

    this._projectUserHttpService.post(toUpdate).then((data) => {
        if (typeof(data) === 'string') {
            this._dialogService.error(data);
        }
    }).catch()
    .then(() =>
        this._loadingService.endLoading(loadingId)
    );
  }

  public removeLink(crewMember: CrewMember) {
    let loadingId = this._loadingService.startLoading();

    this._projectUserCrewHttpService.removeLink(this.projectUser.id, crewMember.id).then(data=>{
        if(typeof(data)=='string'){
            this._dialogService.error(data);
        }else{
            this.getProjectUser();
            this._crewMemberHttpService.delete(crewMember.id).then(data =>{
                if(typeof(data)=='string'){
                    this._dialogService.error(data);
                }
            })
        }
    }).catch()
    .then(()=>
        this._loadingService.endLoading(loadingId)
    );
  }

    public editCrewMember(crewMember: CrewMember) {
        let crewMemberDialog = this._dialog.open(AdminEditCrewMemberDialog, {data:
            {
                crewMember
            }});
        crewMemberDialog.afterClosed().subscribe((crewMember: CrewMember) => {
            if (crewMember) {
                this.postCrewMember(crewMember);
            }
        });
    }

    private postCrewMember(crewMember: CrewMember) {
        let loadingId = this._loadingService.startLoading();
        this._crewMemberHttpService.post(crewMember).then((data) => {
            if (typeof(data) === 'string') {
                this._dialogService.error(data);
            }else {
                this.getProjectUser();
            }
        }).catch()
        .then(() =>
            this._loadingService.endLoading(loadingId)
        );
    }
}