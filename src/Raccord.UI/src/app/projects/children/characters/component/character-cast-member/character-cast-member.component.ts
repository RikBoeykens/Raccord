import { Component, Input } from '@angular/core';
import { MdDialog } from '@angular/material';
import { CastMemberSummary } from '../../../cast/model/cast-member-summary.model';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { CastMemberHttpService } from '../../../../children/cast/service/cast-member-http.service';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum }
    from '../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { CastMember } from '../../../cast/model/cast-member.model';
import { EditCastMemberDialogComponent } from '../../../cast';

@Component({
    selector: 'character-cast-member',
    templateUrl: 'character-cast-member.component.html'
})
export class CharacterCastMemberComponent {

    @Input() public projectId: number;
    @Input() public characterId: number;
    @Input() public castMember: CastMemberSummary;

    constructor(
        private _loadingWrapperService: LoadingWrapperService,
        private _castMemberHttpService: CastMemberHttpService,
        private _dialog: MdDialog
    ) {
    }

    public getCastMember() {
        this._loadingWrapperService.Load(
            this._castMemberHttpService.getSummary(this.castMember.id),
            (data) => this.castMember = data
        );
    }

    public getFullName(castMember: CastMemberSummary) {
        return `${castMember.firstName} ${castMember.lastName}`;
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.projectId,
            ProjectPermissionEnum.canEditGeneral
        );
    }

    public addCastMember() {
        let castMember = new CastMember();
        castMember.projectID = this.projectId;
        this.showCastMemberDialog(castMember);
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
            (id) => {
                this.castMember.id = id;
                this.getCastMember();
                this.linkCastMember(id);
            }
        );
    }

    private linkCastMember(castMemberId: number) {
        this._loadingWrapperService.Load(
            this._castMemberHttpService.addLink(castMemberId, this.characterId)
        );
    }
}
