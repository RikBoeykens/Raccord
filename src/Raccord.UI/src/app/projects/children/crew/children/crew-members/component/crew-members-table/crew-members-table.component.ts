import { Component, Input } from '@angular/core';
import { CrewMemberSummary } from '../../../../../../../shared/children/crew';

@Component({
  selector: 'crew-members-table',
  templateUrl: 'crew-members-table.component.html',
})
export class CrewMembersTableComponent {
  @Input() public crewMembers: CrewMemberSummary[];
  @Input() public projectId: number;
  public displayedColumns = [
    'image',
    'name',
    'job',
    'phone',
    'mail'
  ];

  public getFullName(crewMember: CrewMemberSummary) {
    return `${crewMember.firstName} ${crewMember.lastName}`;
  }
}
