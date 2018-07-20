import { Component, Input } from '@angular/core';
import { CastMember } from '../../../../../../../shared/children/cast';
import { RouteSettings, LoadingWrapperService } from '../../../../../../../shared';
import { MatDialog } from '../../../../../../../../../node_modules/@angular/material';
import { Character } from '../../../../../../../shared/children/characters';
import {
  AdminChooseCharactersDialogComponent,
  AdminFullCastMember,
  AdminChooseCastMemberDialogComponent
} from '../../../../../..';
import { User } from '../../../../../../../shared/children/users';
import {
  AdminCastMemberHttpService
} from '../../../../../cast-members/service/admin-cast-member-http.service';
import {
  AdminProjectUserCastHttpService
} from '../../service/admin-project-user-cast-http.service';

@Component({
  selector: 'admin-project-user-cast-member',
  templateUrl: 'admin-project-user-cast-member.component.html',
})
export class AdminProjectUserCastMemberComponent {
  @Input() public castMember: AdminFullCastMember;
  @Input() public projectUserId: number;
  @Input() public projectId: number;
  @Input() public user: User;

  constructor(
    private _dialog: MatDialog,
    private _loadingWrapperService: LoadingWrapperService,
    private _adminCastMemberHttpService: AdminCastMemberHttpService,
    private _adminProjectUserCastHttpService: AdminProjectUserCastHttpService
  ) {}

  public getCastMemberLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.CAST}/${this.castMember.id}`;
  }

  public getFullName() {
    return `${this.castMember.firstName} ${this.castMember.lastName}`;
  }

  public showAddCastMember() {
    const chooseCharactersDialog = this._dialog.open(AdminChooseCharactersDialogComponent, {data:
      {
          selectedCharacters: [],
          projectId: this.projectId,
          title: 'Add Cast Member'
      }});
    chooseCharactersDialog.afterClosed().subscribe((returnedInfo: {
      characterIds: number[]
    }) => {
      if (returnedInfo) {
        this.addCastMember(returnedInfo.characterIds);
      }
    });
  }

  public showEditCastMember() {
    const chooseCharactersDialog = this._dialog.open(AdminChooseCharactersDialogComponent, {data:
      {
          selectedCharacters: this.castMember.characters,
          projectId: this.projectId,
          title: 'Edit Cast Member'
      }});
    chooseCharactersDialog.afterClosed().subscribe((returnedInfo: {
      characterIds: number[]
    }) => {
      if (returnedInfo) {
        this.updateCastMemberCharacters(returnedInfo.characterIds, this.castMember.id);
      }
    });
  }

  public showLinkCastMember() {
    const linkCastMemberDialog = this._dialog.open(AdminChooseCastMemberDialogComponent, {data:
    {
      projectId: this.projectId
    }});
    linkCastMemberDialog.afterClosed().subscribe((returnedInfo: {
      castMemberId: number
    }) => {
      if (returnedInfo) {
        this.linkCastMember(returnedInfo.castMemberId);
      }
    });
  }

  private addCastMember(characterIds: number[]) {
    const castMember = new CastMember({
      id: 0,
      firstName: this.user.firstName,
      lastName: this.user.lastName,
      telephone: '',
      email: this.user.email,
      projectID: this.projectId
    });
    this._loadingWrapperService.Load(
      this._adminCastMemberHttpService.post(castMember),
      (castMemberId: number) => {
        this.linkCastMember(castMemberId, characterIds);
      }
    );
  }

  private linkCastMember(
    castMemberId: number,
    updatedCharacterIds?: number[]
  ) {
    this._loadingWrapperService.Load(
      this._adminProjectUserCastHttpService.addLink(this.projectUserId, castMemberId),
      () => {
        if (updatedCharacterIds) {
          this.updateCastMemberCharacters(updatedCharacterIds, castMemberId);
        } else {
          this.getCastMember(castMemberId);
        }
      }
    );
  }

  private updateCastMemberCharacters(updatedCharacterIds: number[], castMemberId: number) {
    const toAddCharacters = this.getToAddCharacterIds(updatedCharacterIds);
    const toRemoveCharacters = this.getToRemoveCharacterIds(updatedCharacterIds);
    const updateCharacterPromises: Array<Promise<any>> = new Array<Promise<any>>();
    toAddCharacters.forEach((characterId: number) => {
      updateCharacterPromises.push(
        this._adminCastMemberHttpService.addLink(castMemberId, characterId)
      );
    });
    toRemoveCharacters.forEach((characterId: number) => {
      updateCharacterPromises.push(
        this._adminCastMemberHttpService.removeLink(castMemberId, characterId)
      );
    });
    this.updateCastMemberRecursive(updateCharacterPromises, () => this.getCastMember(castMemberId));
  }

  private updateCastMemberRecursive(promises: Array<Promise<any>>, onComplete: () => void) {
    if (promises.length) {
      const currentPromise = promises.pop();
      this._loadingWrapperService.Load(
        currentPromise,
        () => this.updateCastMemberRecursive(promises, onComplete)
      );
    } else {
      onComplete();
    }
  }

  private getToAddCharacterIds(updatedCharacterIds: number[]): number[] {
    if (!this.castMember) {
      return updatedCharacterIds;
    }

    return updatedCharacterIds.filter((id: number) =>
      this.castMember.characters.findIndex((character: Character) => character.id === id) === -1
    );
  }

  private getToRemoveCharacterIds(updatedCharacterIds: number[]): number[] {
    if (!this.castMember) {
      return [];
    }

    return this.castMember.characters.filter((character: Character) =>
      updatedCharacterIds.findIndex((id: number) => character.id === id) === -1
    ).map((character: Character) => character.id);
  }

  private getCastMember(castMemberId?: number) {
    if (this.castMember) {
      castMemberId = this.castMember.id;
    }
    this._loadingWrapperService.Load(
      this._adminCastMemberHttpService.get(castMemberId),
      (foundCastMember: AdminFullCastMember) => this.castMember = foundCastMember
    );
  }
}
