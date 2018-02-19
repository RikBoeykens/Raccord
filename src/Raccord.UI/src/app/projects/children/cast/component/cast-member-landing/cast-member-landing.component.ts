import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MdDialog } from '@angular/material';
import { CastMemberHttpService } from '../../service/cast-member-http.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { FullCastMember } from '../../model/full-cast-member.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from
    '../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { CastMember } from '../../model/cast-member.model';
import { EditCastMemberDialogComponent }
    from '../edit-cast-member-dialog/edit-cast-member-dialog.component';

@Component({
    templateUrl: 'cast-member-landing.component.html',
})
export class CastMemberLandingComponent implements OnInit {

    public castMember: FullCastMember;
    public project: ProjectSummary;

    constructor(
        private _castMemberHttpService: CastMemberHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _dialogService: DialogService,
        private _dialog: MdDialog,
        private _route: ActivatedRoute,
        private _router: Router
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            castMember: FullCastMember,
            project: ProjectSummary
        }) => {
            this.castMember = data.castMember;
            this.project = data.project;
        });
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canEditGeneral
        );
    }

    public updateCastMember() {
        let updateCastMember = new CastMember(this.castMember);
        let castMemberDialog = this._dialog.open(EditCastMemberDialogComponent, {data:
            {
                castMember: updateCastMember,
            }});
        castMemberDialog.afterClosed().subscribe((returnedCastMember: CastMember) => {
            if (returnedCastMember) {
                this.postCastMember(returnedCastMember);
            }
        });
    }

    public getFullName(castMember: CastMember) {
        return `${castMember.firstName} ${castMember.lastName}`;
    }

    private getCastMember() {
        this._loadingWrapperService.Load(
            this._castMemberHttpService.get(this.castMember.id),
            (data) => this.castMember = data
        );
    }

    private postCastMember(castMember: CastMember) {
        this._loadingWrapperService.Load(
            this._castMemberHttpService.post(castMember),
            () => this.getCastMember()
        );
    }
}