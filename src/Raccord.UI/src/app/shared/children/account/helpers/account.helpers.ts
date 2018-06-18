import { UserProfileSummary } from '../../users';
import { UserProjectSummary } from '../../projects';
import { UserPermissionSummary } from '../../users';
import { ProjectPermissionSummary } from '../../users';
import { ProjectPermissionEnum } from '../../users';

export class AccountHelpers {

  public static setUser(userSummary: UserProfileSummary) {
    sessionStorage.setItem(this._userIdKey, userSummary.id);
    sessionStorage.setItem(this._userNameKey, `${userSummary.firstName} ${userSummary.lastName}`);
    sessionStorage.setItem(this._userHasImageKey, userSummary.hasImage.toString());
  }

  public static setUserProjects(projectSummaries: UserProjectSummary[]) {
    projectSummaries.forEach((project) => {
      if (project.hasCrew) {
        this.setUserProjectType(project.id, this._userProjectHasCrew);
      }
      if (project.hasCast) {
        this.setUserProjectType(project.id, this._userProjectHasCast);
      }
    });
  }

  public static setUserProjectType(projectID: number, type: string) {
    sessionStorage.setItem(
      this.constructProjectSummaryString(projectID, type), true.toString()
    );
  }

  public static setPermissions(permissionSummary: UserPermissionSummary) {
    sessionStorage.setItem(this._userIsAdminKey, permissionSummary.isAdmin.toString());
    permissionSummary.projectPermissions.forEach((project: ProjectPermissionSummary) => {
      project.projectPermissions.forEach((permission: ProjectPermissionEnum) => {
        sessionStorage.setItem(
          this.constructProjectPermissionString(project.projectID, permission), true.toString()
        );
      });
    });
  }

  public static setName(firstName: string, lastName: string) {
    sessionStorage.setItem(this._userNameKey, `${firstName} ${lastName}`);
  }

  public static getUserId(): string {
    return sessionStorage.getItem(this._userIdKey);
  }

  public static getName(): string {
    return sessionStorage.getItem(this._userNameKey);
  }

  public static getHasImage(): boolean {
    return sessionStorage.getItem(this._userHasImageKey) === true.toString();
  }

  public static isAdmin(): boolean {
    return sessionStorage.getItem(this._userIsAdminKey) === true.toString();
  }

  public static hasProjectPermission(projectID: number, permission: ProjectPermissionEnum) {
    return sessionStorage.getItem(
      this.constructProjectPermissionString(projectID, permission)
    ) === true.toString();
  }

  public static hasCrew(projectID: number) {
    return this.hasType(projectID, this._userProjectHasCrew);
  }

  public static hasCast(projectID: number) {
    return this.hasType(projectID, this._userProjectHasCast);
  }

  public static hasType(projectID: number, type: string) {
    return sessionStorage.getItem(
      this.constructProjectSummaryString(projectID, type)
    ) === true.toString();
  }

  public static removeUser() {
    sessionStorage.clear();
  }

  private static readonly _userIdKey = 'user_id';
  private static readonly _userNameKey = 'user_name';
  private static readonly _userIsAdminKey = 'user_is_admin';
  private static readonly _userHasImageKey = 'user_has_image';
  private static readonly _userProjectPermissionKey = 'user_project_permission';
  private static readonly _userProjectSummaryKey = 'user_project_summary';
  private static readonly _userProjectHasCrew = 'has_crew';
  private static readonly _userProjectHasCast = 'has_cast';

  private static constructProjectPermissionString(
    projectID: number,
    permission: ProjectPermissionEnum
  ) {
    return `${this._userProjectPermissionKey}_${projectID}_${permission}`;
  }
  private static constructProjectSummaryString(
    projectID: number,
    type: string
  ) {
    return `${this._userProjectPermissionKey}_${projectID}_${type}`;
  }
}
