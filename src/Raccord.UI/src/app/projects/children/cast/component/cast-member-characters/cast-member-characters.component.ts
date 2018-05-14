import { Component, Input } from '@angular/core';
import { CastMemberHttpService } from '../../service/cast-member-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from
    '../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { CharacterSummary } from '../../../characters/model/character-summary.model';
import { LoadingWrapperService } from '../../../../../shared';
import { CharacterHttpService } from
    '../../../../children/characters/service/character-http.service';

@Component({
    selector: 'cast-member-characters',
    templateUrl: 'cast-member-characters.component.html'
})
export class CastMemberCharactersComponent {

    @Input() public projectId: number;
    @Input() public castMemberId: number;
    @Input() public characters: CharacterSummary[];

    constructor(
        private _castMemberHttpService: CastMemberHttpService,
        private _characterHttpService: CharacterHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ) {
    }

    public removeLink(character: CharacterSummary) {
        this._loadingWrapperService.Load(
            this._castMemberHttpService.removeLink(this.castMemberId, character.id),
            () => this.getCharacters()
        );
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.projectId,
            ProjectPermissionEnum.canEditGeneral
        );
    }

    private getCharacters() {
        this._loadingWrapperService.Load(
            this._characterHttpService.getAllForCastMember(this.castMemberId),
            (data) => this.characters = data
        );
    }
}
