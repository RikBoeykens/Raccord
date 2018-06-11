import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MdDialog } from '@angular/material';
import { FullProjectUser } from '../../model/full-project-user.model';
import { AdminProjectUserHttpService } from '../../service/admin-project-user-http.service';
import { AdminProjectUserCrewHttpService }
    from '../../service/admin-project-user-crew-http.service';
import { LoadingService } from '../../../../loading/service/loading.service';
import { DialogService } from '../../../../shared/service/dialog.service';
import { CrewMemberSummary }
    from '../../../../projects/children/crew/crew-members/model/crew-member-summary.model';
import { CrewMember }
    from '../../../../projects/children/crew/crew-members/model/crew-member.model';
import { CrewMemberHttpService }
    from '../../../../projects/children/crew/crew-members/service/crew-member-http.service';
import { AdminEditCrewMemberDialog }
    from '../admin-edit-crew-member-dialog/admin-edit-crew-member-dialog.component';
import { AdminAddCastDialogComponent }
    from '../admin-add-cast-dialog/admin-add-cast-dialog.component';
import { ProjectRole } from '../../../project-roles/model/project-role.model';
import { ProjectUser } from '../../model/project-user.model';
import { LoadingWrapperService } from '../../../../shared/service/loading-wrapper.service';
import { Character } from '../../../../projects/children/characters/model/character.model';
import { AdminProjectUserCastHttpService } from
    '../../service/admin-project-user-cast-http.service';
import { CastMemberSummary } from
    '../../../../projects/children/cast/model/cast-member-summary.model';
import { CastMemberHttpService }
    from '../../../../projects/children/cast/service/cast-member-http.service';
import { CastMember } from '../../../../projects/children/cast/model/cast-member.model';
import { CrewUnit } from '../../../../projects/children/crew/crew-units/model/crew-unit.model';
import { AdminCrewUnitMemberHttpService } from
    '../../../crew-units/service/admin-crew-unit-member-http.service';
import { LinkedProjectUserUser } from '../../model/linked-project-user-user.model';
import { CrewUnitHttpService } from
    '../../../../projects/children/crew/crew-units/service/crew-unit-http.service';
import { CrewUnitSummary }
    from '../../../../projects/children/crew/crew-units/model/crew-unit-summary.model';
import { ChooseCrewUnitDialogComponent, CrewDepartmentHttpService, EditCastMemberDialogComponent } from '../../../../projects';
import { LinkedCrewUnit }
    from '../../../../projects/children/crew/crew-units/model/linked-crew-unit.model';
import { ProjectUserCrewUnit } from
    '../../../../projects/children/crew/crew-units/model/project-user-crew-unit.model';
import { AdminCrewUnitMemberCrewMembersHttpService } from
    '../../../crew-units/service/admin-crew-unit-member-crew-members-http.service';
import { CrewDepartment } from '../../../../projects/children/crew/departments/model/crew-department.model';
import { AdminAddCrewMemberDialogComponent, AdminLinkCastDialogComponent } from '../../..';
import { CreateCrewUnitMemberCrewMember } from '../../../crew-units/model/create-crew-unit-member-crew-member.model';
import { CreateCrewMember } from '../../../crew-units/model/create-crew-member.model';

@Component({
  templateUrl: 'admin-project-user-landing.component.html',
})
export class AdminProjectUserLandingComponent implements OnInit  {

  public projectUser: FullProjectUser;
  public projectRoles: ProjectRole[];

  constructor(
      private _projectUserHttpService: AdminProjectUserHttpService,
      private _projectUserCastHttpService: AdminProjectUserCastHttpService,
      private _crewUnitMemberCrewMembersHttpService: AdminCrewUnitMemberCrewMembersHttpService,
      private _crewMemberHttpService: CrewMemberHttpService,
      private _castMemberHttpService: CastMemberHttpService,
      private _crewUnitMemberHttpService: AdminCrewUnitMemberHttpService,
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
          projectUser: FullProjectUser,
          projectRoles: ProjectRole[],
        }) => {
          this.projectUser = data.projectUser;
          this.projectRoles = data.projectRoles;
      });
  }

  public getProjectUser() {
    this._loadingWrapperService.Load(
        this._projectUserHttpService.get(this.projectUser.id),
        (data) => this.projectUser = data
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

  public removeCastLink(character: Character) {
    this._loadingWrapperService.Load(
        this._projectUserCastHttpService.removeLink(this.projectUser.id, character.id),
        () => this.getProjectUser()
    );
  }

  public removeCrewMemberLink(crewUnit: ProjectUserCrewUnit, crewMember: CrewMember) {
    let loadingId = this._loadingService.startLoading();

    this._crewUnitMemberCrewMembersHttpService
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

  public showLinkCastMember() {
    this._loadingWrapperService.Load(
        this._castMemberHttpService.getAll(this.projectUser.project.id),
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
                    let newCrewMember = new CreateCrewUnitMemberCrewMember({
                        crewUnitMemberID: crewUnit.linkID,
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

    public showAddCrewUnitMember() {
      this._loadingWrapperService.Load(
          this._crewUnitHttpService.getAll(this.projectUser.project.id),
          (data: CrewUnitSummary[]) => {
              let availableCrewUnits = data.filter((crewUnit: CrewUnitSummary) =>
                this.projectUser.crewUnits.findIndex(
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
            this._crewUnitMemberHttpService.removeLink(crewUnit.linkID),
            () => {
                this.getUnits();
            }
        );
    }

    public showAddCastMemberDialog() {
        let castMember = new CastMember();
        castMember.projectID = this.projectUser.project.id;
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
            this._projectUserCastHttpService.addLink(this.projectUser.id, castMemberId),
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
            this._crewUnitMemberHttpService.addLink(this.projectUser.id, crewUnit.id),
            () => {
                this.getUnits();
            }
        );
    }

    private getUnits() {
        this._loadingWrapperService.Load(
            this._crewUnitMemberHttpService.getCrewUnits(this.projectUser.id),
            (data) => this.projectUser.crewUnits = data
        );
    }

    private addCrewMember(crewMember: CreateCrewUnitMemberCrewMember) {
        this._loadingWrapperService.Load(
            this._crewUnitMemberCrewMembersHttpService.post(crewMember),
            () => {
                this.getUnits();
            }
        );
    }
}
