import { UserProfileSummary } from '../../users';
import { UserProjectSummary } from '../../projects';
import { UserPermissionSummary } from '../../users';
import { ProjectPermissionSummary } from '../../users';
import { ProjectPermissionEnum } from '../../users';
import { StorageSettings } from '../../..';

export class AccountHelpers {

  public static setUser(userSummary: UserProfileSummary) {
    localStorage.setItem(StorageSettings.USERIDKEY, userSummary.id);
    localStorage.setItem(StorageSettings.USERNAMEKEY,
      `${userSummary.firstName} ${userSummary.lastName}`);
    localStorage.setItem(StorageSettings.USERHASIMAGEKEY, userSummary.hasImage.toString());
  }

  public static setUserProjects(projectSummaries: UserProjectSummary[]) {
    projectSummaries.forEach((project) => {
      if (project.hasCrew) {
        this.setUserProjectType(project.id, StorageSettings.USERPROJECTHASCREW);
      }
      if (project.hasCast) {
        this.setUserProjectType(project.id, StorageSettings.USERPROJECTHASCAST);
      }
    });
  }

  public static setUserProjectType(projectID: number, type: string) {
    localStorage.setItem(
      this.constructProjectSummaryString(projectID, type), true.toString()
    );
  }

  public static setPermissions(permissionSummary: UserPermissionSummary) {
    localStorage.setItem(StorageSettings.USERISADMINKEY, permissionSummary.isAdmin.toString());
    permissionSummary.projectPermissions.forEach((project: ProjectPermissionSummary) => {
      project.projectPermissions.forEach((permission: ProjectPermissionEnum) => {
        localStorage.setItem(
          this.constructProjectPermissionString(project.projectID, permission), true.toString()
        );
      });
    });
  }

  public static setName(firstName: string, lastName: string) {
    localStorage.setItem(StorageSettings.USERNAMEKEY, `${firstName} ${lastName}`);
  }

  public static getUserId(): string {
    return localStorage.getItem(StorageSettings.USERIDKEY);
  }

  public static getName(): string {
    return localStorage.getItem(StorageSettings.USERNAMEKEY);
  }

  public static getHasImage(): boolean {
    return localStorage.getItem(StorageSettings.USERHASIMAGEKEY) === true.toString();
  }

  public static isAdmin(): boolean {
    return localStorage.getItem(StorageSettings.USERISADMINKEY) === true.toString();
  }

  public static hasProjectPermission(projectID: number, permission: ProjectPermissionEnum) {
    return localStorage.getItem(
      this.constructProjectPermissionString(projectID, permission)
    ) === true.toString();
  }

  public static hasCrew(projectID: number) {
    return this.hasType(projectID, StorageSettings.USERPROJECTHASCREW);
  }

  public static hasCast(projectID: number) {
    return this.hasType(projectID, StorageSettings.USERPROJECTHASCAST);
  }

  public static hasType(projectID: number, type: string) {
    return localStorage.getItem(
      this.constructProjectSummaryString(projectID, type)
    ) === true.toString();
  }

  public static removeUser() {
    localStorage.clear();
  }

  private static constructProjectPermissionString(
    projectID: number,
    permission: ProjectPermissionEnum
  ) {
    return `${StorageSettings.USERPROJECTPERMISSIONKEY}_${projectID}_${permission}`;
  }
  private static constructProjectSummaryString(
    projectID: number,
    type: string
  ) {
    return `${StorageSettings.USERPROJECTPERMISSIONKEY}_${projectID}_${type}`;
  }
}
