import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { UserProfile } from '../model/user-profile.model';
import { UserProfileHttpService } from './user-profile-http.service';
@Injectable()
export class UserProfileResolve implements Resolve<UserProfile> {

  constructor(
      private _userProfileHttpService: UserProfileHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {

    return this._userProfileHttpService.get().then(userProfile => {
      return userProfile;
    });
  }
}