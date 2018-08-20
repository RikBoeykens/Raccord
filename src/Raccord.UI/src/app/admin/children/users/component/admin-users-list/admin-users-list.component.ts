import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material';
import { AdminUserSummary, AdminAddUserDialogComponent } from '../../../..';
import { AdminUserHttpService } from '../../service/admin-user-http.service';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { CreateUser } from '../../model/create-user.model';
import { RouteSettings } from '../../../../../shared';

@Component({
  templateUrl: 'admin-users-list.component.html',
})
export class AdminUsersListComponent implements OnInit {
  public users: AdminUserSummary[] = [];

  constructor(
    private _adminUserHttpService: AdminUserHttpService,
    private _loadingWrapperService: LoadingWrapperService,
    private _dialog: MatDialog,
    private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { users: AdminUserSummary[] }) => {
      this.setUsers(data.users);
    });
  }

  public setUsers(users: AdminUserSummary[]) {
    this.users = users;
  }

  public getUsers() {
    this._loadingWrapperService.Load(
      this._adminUserHttpService.getAll(),
      (data) => this.setUsers(data)
    );
  }

  public showAddUser() {
    this.showAddUserDialog();
  }

  public getBackLink() {
    return `/${RouteSettings.ADMIN}`;
  }

  private showAddUserDialog() {
    const addUserDialog = this._dialog.open(AdminAddUserDialogComponent);
    addUserDialog.afterClosed().subscribe((returnedUser: CreateUser) => {
      if (returnedUser) {
          this.addUser(returnedUser);
      }
    });
  }

  private addUser(user: CreateUser) {
    this._loadingWrapperService.Load(
      this._adminUserHttpService.add(user),
      () => {
        this.getUsers();
      }
    );
  }
}
