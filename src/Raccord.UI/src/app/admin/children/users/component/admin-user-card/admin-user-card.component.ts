import { Input, Component } from '@angular/core';
import { AdminUserSummary } from '../../model/admin-user-summary.model';

@Component({
  selector: 'admin-user-card',
  templateUrl: 'admin-user-card.component.html'
})
export class AdminUserCardComponent {
  @Input() public user: AdminUserSummary;

  public getFullName() {
    return `${this.user.firstName} ${this.user.lastName}`;
  }
}
