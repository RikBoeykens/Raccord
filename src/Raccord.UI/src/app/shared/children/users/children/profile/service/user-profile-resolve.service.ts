import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { UserProfile, UserProfileHttpService } from '../../..';

@Injectable()
export class UserProfileResolve implements Resolve<UserProfile> {

  constructor(
      private _userProfileHttpService: UserProfileHttpService,
      private router: Router
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {

    return this._userProfileHttpService.get().then((userProfile: UserProfile) => userProfile);
  }
}
