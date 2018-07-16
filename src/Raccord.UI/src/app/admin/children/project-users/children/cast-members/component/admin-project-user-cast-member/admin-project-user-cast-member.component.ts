import { Component, Input } from '@angular/core';
import { CastMember } from '../../../../../../../shared/children/cast';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  selector: 'admin-project-user-cast-member',
  templateUrl: 'admin-project-user-cast-member.component.html',
})
export class AdminProjectUserCastMemberComponent {
  @Input() public castMember: CastMember;
  @Input() public projectUserId: number;
  @Input() public projectId: number;

  public getCastMemberLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.CAST}/${this.castMember.id}`;
  }

  public getFullName() {
    return `${this.castMember.firstName} ${this.castMember.lastName}`;
  }
}
