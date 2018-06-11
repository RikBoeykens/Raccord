import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MdDialog } from '@angular/material';
import { UserInvitation } from '../../../../../../invitations/model/user-invitation.model';
import { FullProjectUserInvitation } from '../../model/full-project-user-invitation.model';
import { ProjectRole } from '../../../../../project-roles/model/project-role.model';
import { AdminProjectUserInvitationHttpService } from
    '../../service/admin-project-user-invitation-http.service';
import { AdminProjectUserInvitationCastHttpService } from '../../../../../project-users/service/admin-project-user-invitation-cast-http.service';
import { AdminCrewUnitInvitationMemberCrewMembersHttpService } from '../../../../../crew-units/service/admin-crew-unit-invitation-member-crew-members-http.service';
import { CrewMemberHttpService } from '../../../../../../projects/children/crew/crew-members/service/crew-member-http.service';
import { CastMemberHttpService } from '../../../../../../projects/children/cast/service/cast-member-http.service';
import { AdminCrewUnitInvitationMemberHttpService } from '../../../../../crew-units/service/admin-crew-unit-invitation-member-http.service';
import { CrewUnitHttpService } from '../../../../../../projects/children/crew/crew-units/service/crew-unit-http.service';
import { CrewDepartmentHttpService } from '../../../../../../projects/children/crew/departments/service/crew-department-http.service';
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectUserInvitation } from '../../model/project-user-invitation.model';
import { Character } from '../../../../../../projects/children/characters/model/character.model';
import { ProjectUserCrewUnit } from '../../../../../../projects/children/crew/crew-units/model/project-user-crew-unit.model';
import { CrewMember } from '../../../../../../projects/children/crew/crew-members/model/crew-member.model';
import { CastMemberSummary } from '../../../../../../projects/children/cast/model/cast-member-summary.model';
import { AdminAddCastDialogComponent } from '../../../../../project-users/component/admin-add-cast-dialog/admin-add-cast-dialog.component';
import { CrewDepartment } from '../../../../../../projects/children/crew/departments/model/crew-department.model';
import { CreateCrewUnitInvitationMemberCrewMember } from '../../../../../crew-units/model/create-crew-unit-invitation-member-crew-member.model';
import { AdminAddCrewMemberDialogComponent } from '../../../../../project-users/component/admin-add-crew-member-dialog/admin-add-crew-member-dialog.component';
import { AdminEditCrewMemberDialog } from '../../../../../project-users/component/admin-edit-crew-member-dialog/admin-edit-crew-member-dialog.component';
import { CastMember } from '../../../../../../projects/children/cast/model/cast-member.model';
import { CrewUnitSummary } from '../../../../../../projects/children/crew/crew-units/model/crew-unit-summary.model';
import { ChooseCrewUnitDialogComponent } from '../../../../../../projects/children/crew/crew-units/component/choose-crew-unit-dialog/choose-crew-unit-dialog.component';
import { CrewUnit } from '../../../../../../projects/children/crew/crew-units/model/crew-unit.model';
import { CreateCrewMember } from '../../../../../crew-units/model/create-crew-member.model';
import { AdminLinkCastDialogComponent } from '../../../../../project-users/component/admin-link-cast-dialog/admin-link-cast-dialog.component';

@Component({
  templateUrl: 'admin-project-user-invitation-landing.component.html',
})
export class AdminProjectUserInvitationLandingComponent implements OnInit  {

  public projectUserInvitation: FullProjectUserInvitation;
  public projectRoles: ProjectRole[];

  constructor(
      private _projectUserInvitationHttpService: AdminProjectUserInvitationHttpService,
      private _projectUserInvitationCastHttpService: AdminProjectUserInvitationCastHttpService,
      private _crewUnitInvitationMemberCrewMembersHttpService:
                AdminCrewUnitInvitationMemberCrewMembersHttpService,
      private _crewMemberHttpService: CrewMemberHttpService,
      private _castMemberHttpService: CastMemberHttpService,
      private _crewUnitInvitationMemberHttpService: AdminCrewUnitInvitationMemberHttpService,
      private _crewUnitHttpService: CrewUnitHttpService,
      private _crewDepartmentHttpService: CrewDepartmentHttpService,
      private _loadingWrapperService: LoadingWrapperService,
      private _loadingService: LoadingService,
      private _dialogService: DialogService,
      private route: ActivatedRoute,
      private _dialog: MdDialog
  ) {
  }

  public ngOnInit() {
      this.route.data.subscribe((data: {
          projectUserInvitation: FullProjectUserInvitation,
          projectRoles: ProjectRole[],
        }) => {
          this.projectUserInvitation = data.projectUserInvitation;
          this.projectRoles = data.projectRoles;
      });
  }

  public getProjectUser() {
    this._loadingWrapperService.Load(
        this._projectUserInvitationHttpService.get(this.projectUserInvitation.id),
        (data) => this.projectUserInvitation = data
    );
  }

  public updateProjectUserInvitation() {
    let toUpdate = new ProjectUserInvitation({
        id: this.projectUserInvitation.id,
        projectID: this.projectUserInvitation.project.id,
        userInvitationID: this.projectUserInvitation.userInvitation.id,
        roleID: this.projectUserInvitation.projectRole !== null ?
                    this.projectUserInvitation.projectRole.id !== 0 ?
                        this.projectUserInvitation.projectRole.id : null : null
    });

    this._loadingWrapperService.Load(
        this._projectUserInvitationHttpService.update(toUpdate)
    );
  }

  public removeCastLink(character: Character) {
    this._loadingWrapperService.Load(
        this._projectUserInvitationCastHttpService
            .removeLink(this.projectUserInvitation.id, character.id),
        () => this.getProjectUser()
    );
  }

  public removeCrewMemberLink(crewUnit: ProjectUserCrewUnit, crewMember: CrewMember) {
    let loadingId = this._loadingService.startLoading();

    this._crewUnitInvitationMemberCrewMembersHttpService
            .removeLink(crewUnit.linkID, crewMember.id).then((data) => {
        if (typeof(data) === 'string') {
            this._dialogService.error(data);
        }else {
            this.getProjectUser();
            this._crewMemberHttpService.delete(crewMember.id).then((errorData) => {
                if (typeof(errorData) === 'string') {
                    this._dialogService.error(data);
                }
            });
        }
    }).catch()
    .then(() =>
        this._loadingService.endLoading(loadingId)
    );
  }

  public showAddCrewMember(crewUnit: ProjectUserCrewUnit) {
    this._loadingWrapperService.Load(
        this._crewDepartmentHttpService.getAll(crewUnit.id),
        (data: CrewDepartment[]) => {
            let createCrewMember = new CreateCrewMember();
            let crewMemberDialog = this._dialog.open(AdminAddCrewMemberDialogComponent, {data:
                {
                    crewMember: createCrewMember,
                    departments: data
                }});
            crewMemberDialog.afterClosed()
                    .subscribe((returnedCrewMember: CreateCrewMember) => {
                if (returnedCrewMember) {
                    let newCrewMember = new CreateCrewUnitInvitationMemberCrewMember({
                        crewUnitInvitationMemberID: crewUnit.linkID,
                        jobTitle: returnedCrewMember.jobTitle,
                        departmentID: returnedCrewMember.departmentID
                    });
                    this.addCrewMember(newCrewMember);
                }
            });
        }
    );

  }

    public editCrewMember(crewMember: CrewMember) {
        let crewMemberDialog = this._dialog.open(AdminEditCrewMemberDialog, {data:
            {
                crewMember
            }});
        crewMemberDialog.afterClosed().subscribe((returnedCrewMember: CrewMember) => {
            if (returnedCrewMember) {
                this.postCrewMember(returnedCrewMember);
            }
        });
    }

    public getFullName(castMember: CastMember) {
        return `${castMember.firstName} ${castMember.lastName}`;
    }

    public getInvitationFullName(invitation: UserInvitation) {
        return `${invitation.firstName} ${invitation.lastName}`;
    }

    public showAddCrewUnitMember() {
      this._loadingWrapperService.Load(
          this._crewUnitHttpService.getAll(this.projectUserInvitation.project.id),
          (data: CrewUnitSummary[]) => {
              let availableCrewUnits = data.filter((crewUnit: CrewUnitSummary) =>
                this.projectUserInvitation.crewUnits.findIndex(
                    (existingCrewUnit: ProjectUserCrewUnit) =>
                    existingCrewUnit.id === crewUnit.id) === -1);
              let crewUnitDialog = this._dialog.open(
                  ChooseCrewUnitDialogComponent, {data:
                  {
                      crewUnits: availableCrewUnits
                  }});
              crewUnitDialog.afterClosed().subscribe((returnedCrewUnit: CrewUnit) => {
                  if (returnedCrewUnit) {
                      this.addUnitMemberLink(returnedCrewUnit);
                  }
              });
          }
      );
    }

    public removeUnitMemberLink(crewUnit: ProjectUserCrewUnit) {
        this._loadingWrapperService.Load(
            this._crewUnitInvitationMemberHttpService.removeLink(crewUnit.linkID),
            () => {
                this.getUnits();
            }
        );
    }

    public showLinkCastMember() {
      this._loadingWrapperService.Load(
          this._castMemberHttpService.getAll(this.projectUserInvitation.project.id),
          (data: CastMemberSummary[]) => {
              let castMemberDialog = this._dialog.open(AdminLinkCastDialogComponent, {data:
                  {
                      castMembers: data.filter((cast: CastMemberSummary) =>
                          !cast.userID && !cast.userInvitationID)
                  }});
              castMemberDialog.afterClosed().subscribe((returnedCastMember: CastMemberSummary) => {
                  if (returnedCastMember) {
                      this.addCastLink(returnedCastMember.id);
                  }
              });
          }
      );
    }

    public showAddCastMemberDialog() {
        let castMember = new CastMember();
        castMember.projectID = this.projectUserInvitation.project.id;
        let castMemberDialog = this._dialog.open(AdminAddCastDialogComponent, {data:
            {
                castMember,
            }});
        castMemberDialog.afterClosed().subscribe((returnedCastMember: CastMember) => {
            if (returnedCastMember) {
                this.postCastMember(returnedCastMember);
            }
        });
    }

    private postCastMember(castMember: CastMember) {
        this._loadingWrapperService.Load(
            this._castMemberHttpService.post(castMember),
            (data) => this.addCastLink(data)
        );
    }

    private addCastLink(castMemberId: number) {
        this._loadingWrapperService.Load(
            this._projectUserInvitationCastHttpService
                .addLink(this.projectUserInvitation.id, castMemberId),
            () => {
                this.getProjectUser();
            }
        );
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

    private addUnitMemberLink(crewUnit: CrewUnit) {
        this._loadingWrapperService.Load(
            this._crewUnitInvitationMemberHttpService
                .addLink(this.projectUserInvitation.id, crewUnit.id),
            () => {
                this.getUnits();
            }
        );
    }

    private getUnits() {
        this._loadingWrapperService.Load(
            this._crewUnitInvitationMemberHttpService.getCrewUnits(this.projectUserInvitation.id),
            (data) => this.projectUserInvitation.crewUnits = data
        );
    }

    private addCrewMember(crewMember: CreateCrewUnitInvitationMemberCrewMember) {
        this._loadingWrapperService.Load(
            this._crewUnitInvitationMemberCrewMembersHttpService.post(crewMember),
            () => {
                this.getUnits();
            }
        );
    }
}
