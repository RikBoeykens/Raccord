import { Component, Input } from '@angular/core';
import { RouteSettings, LoadingWrapperService } from '../../../../../../../shared';
import { MatDialog } from '../../../../../../../../../node_modules/@angular/material';
import {
  ProjectLinkCrewUnit,
  CrewUnitSummary,
  CrewDepartment
} from '../../../../../../../shared/children/crew';
import { User } from '../../../../../../../shared/children/users';
import {
  AdminChooseCrewUnitDialogComponent,
  AdminAddCrewUnitMemberCrewMemberDialogComponent,
  CreateCrewUnitMemberCrewMember
} from '../../../../../..';
import {
  AdminCrewUnitHttpService
} from '../../../../../crew/crew-units/service/admin-crew-unit-http.service';
import { AdminCrewUnitMemberHttpService } from '../../service/admin-crew-unit-member-http.service';
import {
  AdminCrewDepartmentHttpService
} from '../../../../../crew/crew-departments/service/admin-crew-department-http.service';
import {
  AdminCrewUnitMemberCrewMembersHttpService
} from '../../service/admin-crew-unit-member-crew-member-http.service';

@Component({
  selector: 'admin-project-user-crew',
  templateUrl: 'admin-project-user-crew.component.html',
})
export class AdminProjectUserCrewComponent {
  @Input() public crewUnits: ProjectLinkCrewUnit[];
  @Input() public projectUserId: number;
  @Input() public projectId: number;
  @Input() public user: User;

  constructor(
    private _dialog: MatDialog,
    private _adminCrewUnitHttpService: AdminCrewUnitHttpService,
    private _adminCrewUnitMemberHttpService: AdminCrewUnitMemberHttpService,
    private _adminCrewDepartmentHttpService: AdminCrewDepartmentHttpService,
    private _adminCrewUnitMemberCrewMemberHttpService: AdminCrewUnitMemberCrewMembersHttpService,
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
      this._adminCrewUnitMemberHttpService.addLink(this.projectUserId, crewUnitId),
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
      this._adminCrewUnitMemberCrewMemberHttpService.post(crewMemberInfo),
      () => this.getCrewUnits()
    );
  }

  private getCrewUnits() {
    this._loadingWrapperService.Load(
      this._adminCrewUnitMemberHttpService.getCrewUnits(this.projectUserId),
      (crewUnits: ProjectLinkCrewUnit[]) => this.crewUnits = crewUnits
    );
  }
}
