import { Component, Input } from '@angular/core';
import { RouteSettings } from '../../../../../../../shared';
import { CallsheetCharacterCharacter } from '../../model/callsheet-character-character.model';
import { CharacterCallCallType, CallType } from '../../../../../..';
import { CastMember } from '../../../../../../../shared/children/cast';

@Component({
  selector: 'callsheet-characters-table',
  templateUrl: 'callsheet-characters-table.component.html',
})
export class CallsheetCharactersTableComponent {
  @Input() public callsheetCharacters: CallsheetCharacterCharacter[];
  @Input() public projectId: number;

  public displayedColumns(): string[] {
    return [
      'image', 'character', 'castmember'
    ].concat(this.getCharacterCalls().map((callType: CallType) => `call${callType.id}`));
  }

  public showCharacterImage(callsheetCharacter: CallsheetCharacterCharacter) {
      return callsheetCharacter.castMember.id === 0 &&
      callsheetCharacter.character.primaryImage.id !== 0;
  }

  public showUserImage(callsheetCharacter: CallsheetCharacterCharacter) {
    return callsheetCharacter.castMember.id !== 0;
  }

  public getFullName(castMember: CastMember) {
    return `${castMember.firstName} ${castMember.lastName}`;
  }

  public getCharacterLink(callsheetCharacter: CallsheetCharacterCharacter): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.CHARACTERS}/${callsheetCharacter.character.id}`;
  }

  public getCastMemberLink(callsheetCharacter: CallsheetCharacterCharacter): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.CAST}/${callsheetCharacter.castMember.id}`;
  }

  public getCharacterCalls(): CallType[] {
    if (this.callsheetCharacters && this.callsheetCharacters.length) {
      return this.callsheetCharacters[0].calls.map((characterCallCallType: CharacterCallCallType) =>
        characterCallCallType.callType);
    }
    return [];
  }
}
