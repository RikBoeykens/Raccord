import { Component, Input } from '@angular/core';
import { CastMemberSummary } from '../../../../../../../../../shared/children/cast';
import { RouteSettings } from '../../../../../../../../../shared';

@Component({
  selector: 'character-cast-member',
  templateUrl: 'character-cast-member.component.html',
})
export class CharacterCastMemberComponent {

  @Input() public castMember: CastMemberSummary;
  @Input() public projectId: number;

  public getFullName() {
    return `${this.castMember.firstName} ${this.castMember.lastName}`;
  }

  public getCastMemberLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.CAST}/${this.castMember.id}`;
  }
}
