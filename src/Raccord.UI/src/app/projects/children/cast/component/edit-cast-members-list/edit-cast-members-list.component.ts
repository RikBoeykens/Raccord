import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MdDialog } from '@angular/material';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from
    '../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { CastMemberSummary } from '../../model/cast-member-summary.model';
import { CastMemberHttpService } from '../../service/cast-member-http.service';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { CastMember } from '../../model/cast-member.model';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { EditCastMemberDialogComponent }
    from '../edit-cast-member-dialog/edit-cast-member-dialog.component';

@Component({
    templateUrl: 'edit-cast-members-list.component.html',
})
export class EditCastMembersListComponent implements OnInit {

    public castMembers: CastMemberSummary[];
    public project: ProjectSummary;

    constructor(
        private _castMemberHttpService: CastMemberHttpService,
        private _dialogService: DialogService,
        private _loadingWrapperService: LoadingWrapperService,
        private _route: ActivatedRoute,
        private _router: Router,
        private _dialog: MdDialog
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data:
            {
                castMembers: CastMemberSummary[],
                project: ProjectSummary
            }) => {
            this.castMembers = data.castMembers;
            this.project = data.project;
        });
    }

    public addCastMember() {
        let castMember = new CastMember();
        castMember.projectID = this.project.id;
        this.showCastMemberDialog(castMember);
    }

    public editCastMember(castMember: CastMember) {
        this.showCastMemberDialog(castMember);
    }

    public removeCastMember(castMember: CastMember) {
        if (this._dialogService.confirm(
            `Are you sure you want to remove cast member ${this.getFullName(castMember)}?`
        )) {
            this._loadingWrapperService.Load(
                this._castMemberHttpService.delete(castMember.id)
            );
        }
    }

    public getFullName(castMember: CastMember) {
        return `${castMember.firstName} ${castMember.lastName}`;
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canEditGeneral
        );
    }

    public getCanEditCastMember(castMember: CastMemberSummary)
    {
        return !castMember.userID && !castMember.userInvitationID;
    }

    private getCastMembers() {
        this._loadingWrapperService.Load(
            this._castMemberHttpService.getAll(this.project.id),
            (data) => this.castMembers = data
        );
    }

    private showCastMemberDialog(castMember: CastMember) {
        let castMemberDialog = this._dialog.open(EditCastMemberDialogComponent, {data:
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
            () => this.getCastMembers()
        );
    }
}
