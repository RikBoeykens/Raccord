import { Injectable } from '@angular/core';
import { AccountHttpService } from '../../account/service/account-http.service';
import { UserProfileHttpService } from '../../profile/service/user-profile-http.service';
import { ProjectHttpService } from '../../projects/service/project-http.service';
import { Login } from '../model/login.model';
import { AuthService } from './auth.service';
import { UserProfileSummary } from '../../profile/model/user-profile-summary.model';
import { AccountHelpers } from '../../account/helpers/account.helper';
import { UserPermissionSummary } from '../../account/model/user-permission-summary.model';
import { UserProjectSummary } from '../../projects/model/user-project-summary.model';

@Injectable()
export class LoginService {
  constructor(
    private _authService: AuthService,
    private _accountService: AccountHttpService,
    private _userProfileHttpService: UserProfileHttpService,
    private _projectHttpService: ProjectHttpService,
  ) {}

  public login(login: Login): Promise<any> {
    return this._authService.login(login).then(() => {
      this._userProfileHttpService.getSummary().then((profileData) => {
        AccountHelpers.setUser(<UserProfileSummary> profileData);
      });
      this._accountService.getProjectPermissions().then((permissionData) => {
        AccountHelpers.setPermissions(<UserPermissionSummary> permissionData);
      });
      this._projectHttpService.getSummaries().then((projectSummaries) => {
        AccountHelpers.setUserProjects(<UserProjectSummary[]> projectSummaries);
      });
    });
  }
}
