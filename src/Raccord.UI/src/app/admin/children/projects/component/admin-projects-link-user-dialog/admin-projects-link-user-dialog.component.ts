import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProjectRole, User } from '../../../../../shared/children/users';

@Component({
  templateUrl: 'admin-projects-link-user-dialog.component.html',
})

export class AdminProjectsLinkUserDialogComponent {
  public selectedUser: User = new User();
  public searchText: string;
  public chosenRoleId: number;
  public availableRoles: ProjectRole[];
  // tslint:disable-next-line:max-line-length
  public filteredUsers: User[] = [
    new User({id: '1', email: 'a@b.com', firstName: 'Rik', lastName: 'Boeykens'}),
    new User({id: '2', email: 'a@b.com', firstName: 'Jan', lastName: 'Smith'}),
    new User({id: '3', email: 'a@b.com', firstName: 'Janine', lastName: 'Bischops'}),
    new User({id: '4', email: 'a@b.com', firstName: 'Karel', lastName: 'Eggers'}),
    new User({id: '5', email: 'a@b.com', firstName: 'Jaap', lastName: 'Van In'}),
    new User({id: '6', email: 'a@b.com', firstName: 'Sarah', lastName: 'Boeykens'}),
  ];

  constructor(
    private _dialogRef: MatDialogRef<AdminProjectsLinkUserDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      projectRoles: ProjectRole[]
    }
  ) {
    this.availableRoles = data.projectRoles;
  }

  public submit() {
    this._dialogRef.close({userId: this.selectedUser.id, roleId: this.chosenRoleId});
  }

  public getName(user: User) {
    return `${user.firstName} ${user.lastName}`;
  }

  public onSelectionChanged(event$) {
    this.selectedUser = event$.option.value;
  }

  public clearSearch(value) {
    this.searchText = '';
    return '';
  }

  public removeSelectedUser() {
    this.selectedUser = new User();
  }
}
