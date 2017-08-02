import { UserSummary } from "../model/user-summary.model";

export class AccountHelpers {
  public static setUser(userSummary: UserSummary) {
    sessionStorage.setItem('user_email', userSummary.email);
    sessionStorage.setItem('user_is_admin', userSummary.isAdmin.toString());
  }

  public static getEmail(): string {
    return sessionStorage.getItem('user_email');
  }

  public static isAdmin(): boolean {
    return sessionStorage.getItem('user_is_admin')===true.toString();
  }

  public static removeUser(){
    sessionStorage.removeItem('user_email');
    sessionStorage.removeItem('user_is_admin');
  }
}