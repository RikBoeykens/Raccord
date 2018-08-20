import { Component, Input } from '@angular/core';
import { LoadingWrapperService } from '../../../../../../../shared';
import { MatDialog } from '../../../../../../../../../node_modules/@angular/material';
import {
  ProjectLinkCrewUnit,
  CrewUnitSummary,
  CrewDepartment
} from '../../../../../../../shared/children/crew';
import {
  AdminChooseCrewUnitDialogComponent,
  AdminAddCrewUnitMemberCrewMemberDialogComponent,
  CreateCrewUnitMemberCrewMember
} from '../../../../../..';
import {
  AdminCrewUnitHttpService
} from '../../../../../crew/crew-units/service/admin-crew-unit-http.service';
import {
  AdminCrewUnitInvitationMemberHttpService
} from '../../service/admin-crew-unit-invitation-member-http.service';
import {
  AdminCrewDepartmentHttpService
} from '../../../../../crew/crew-departments/service/admin-crew-department-http.service';
import {
  AdminCrewUnitInvitationMemberCrewMembersHttpService
} from '../../service/admin-crew-unit-invitation-member-crew-member-http.service';
import { UserInvitation } from '../../../../../../../shared/children/user-invitations';

@Component({
  selector: 'admin-project-user-invitation-crew',
  templateUrl: 'admin-project-user-invitation-crew.component.html',
})
export class AdminProjectUserInvitationCrewComponent {
  @Input() public crewUnits: ProjectLinkCrewUnit[];
  @Input() public projectUserInvitationId: number;
  @Input() public projectId: number;
  @Input() public userInvitation: UserInvitation;

  constructor(
    private _dialog: MatDialog,
    private _adminCrewUnitHttpService: AdminCrewUnitHttpService,
    private _adminCrewUnitInvitationMemberHttpService: AdminCrewUnitInvitationMemberHttpService,
    private _adminCrewDepartmentHttpService: AdminCrewDepartmentHttpService,
    // tslint:disable-next-line:max-line-length
    private _adminCrewUnitInvitationMemberCrewMemberHttpService: AdminCrewUnitInvitationMemberCrewMembersHttpService,
    private _loadingWrapperService: LoadingWrapperService
  ) {}

  public initShowAddCrewUnit() {
    this._loadingWrapperService.Load(
      this._adminCrewUnitHttpService.getforProject(this.projectId),
      (crewUnits: CrewUnitSummary[]) => this.showAddCrewUnit(crewUnits)
    );
  }

  public initShowAddCrewMember(crewUnit: ProjectLinkCrewUnit) {
    this._loadingWrapperService.Load(
      this._adminCrewDepartmentHttpService.getAll(crewUnit.id),
      (crewDepartments: CrewDepartment[]) =>
        this.showAddCrewMember(crewUnit.linkID, crewDepartments)
    );
  }

  private showAddCrewUnit(crewUnits: CrewUnitSummary[]) {
    const chooseCrewUnitDialog = this._dialog.open(AdminChooseCrewUnitDialogComponent, {data:
    {
      title: 'Add Unit',
      crewUnits
    }});
    chooseCrewUnitDialog.afterClosed().subscribe((returnedInfo: {
      crewUnitId: number
    }) => {
      if (returnedInfo) {
        this.linkCrewUnit(returnedInfo.crewUnitId);
      }
    });
  }

  private linkCrewUnit(crewUnitId: number) {
    this._loadingWrapperService.Load(
      this._adminCrewUnitInvitationMemberHttpService.addLink(
        this.projectUserInvitationId,
        crewUnitId
      ),
      () => this.getCrewUnits()
    );
  }

  private showAddCrewMember(linkID: number, departments: CrewDepartment[]) {
    const addCrewMemberDialog = this._dialog.open(
      AdminAddCrewUnitMemberCrewMemberDialogComponent, {
        data:
        {
          linkID,
          departments
        }});
    addCrewMemberDialog.afterClosed().subscribe((returnedInfo: {
      crewMemberInfo: CreateCrewUnitMemberCrewMember
    }) => {
      if (returnedInfo) {
        this.createCrewMember(returnedInfo.crewMemberInfo);
      }
    });
  }

  private createCrewMember(crewMemberInfo: CreateCrewUnitMemberCrewMember) {
    this._loadingWrapperService.Load(
      this._adminCrewUnitInvitationMemberCrewMemberHttpService.post(crewMemberInfo),
      () => this.getCrewUnits()
    );
  }

  private getCrewUnits() {
    this._loadingWrapperService.Load(
      this._adminCrewUnitInvitationMemberHttpService.getCrewUnits(this.projectUserInvitationId),
      (crewUnits: ProjectLinkCrewUnit[]) => this.crewUnits = crewUnits
    );
  }
}
