import { Input, Component } from '@angular/core';
import { CastMemberSummary } from '../../model/cast-member-summary.model';

@Component({
  selector: 'cast-member-card',
  templateUrl: 'cast-member-card.component.html'
})
export class CastMemberCardComponent {
  @Input() public castMember: CastMemberSummary;

  public getFullName() {
      return `${this.castMember.firstName} ${this.castMember.lastName}`;
  }
}
