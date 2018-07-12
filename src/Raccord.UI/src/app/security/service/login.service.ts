import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { AccountHttpService } from '../../shared/children/account/service/account-http.service';
import { Login } from '..';
import { AccountHelpers } from '../../shared/children/account';
import { UserProfileSummary } from '../../shared/children/users';
import { UserPermissionSummary } from '../../shared/children/users';
import { UserProjectSummary } from '../../shared/children/projects';
// tslint:disable-next-line:max-line-length
import { UserProfileHttpService } from '../../shared/children/users/children/profile/service/user-profile-http.service';
import { ProjectHttpService } from '../../shared/children/projects/service/project-http.service';

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
      const profilePromise = this._userProfileHttpService.getSummary().then(
        (profileData: UserProfileSummary) => {
        AccountHelpers.setUser(profileData);
      });
      const permissionPromise = this._accountService.getProjectPermissions().then(
        (permissionData: UserPermissionSummary) => {
        AccountHelpers.setPermissions(permissionData);
      });
      const projectPromise = this._projectHttpService.getSummaries().then(
        (projectSummaries: UserProjectSummary[]) => {
        AccountHelpers.setUserProjects(projectSummaries);
      });
      return Promise.all([profilePromise, permissionPromise, projectPromise]);
    });
  }
}
