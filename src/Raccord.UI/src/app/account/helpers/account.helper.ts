import { UserSummary } from "../model/user-summary.model";

export class AccountHelpers {
  public static setUser(userSummary: UserSummary) {
    sessionStorage.setItem('user_name', `${userSummary.firstName} ${userSummary.lastName}`);
    sessionStorage.setItem('user_is_admin', userSummary.isAdmin.toString());
  }

  public static setName(firstName: string, lastName: string) {
    sessionStorage.setItem('user_name', `${firstName} ${lastName}`);
  }

  public static getName(): string {
    return sessionStorage.getItem('user_name');
  }

  public static isAdmin(): boolean {
    return sessionStorage.getItem('user_is_admin')===true.toString();
  }

  public static removeUser(){
    sessionStorage.removeItem('user_name');
    sessionStorage.removeItem('user_is_admin');
  }
}