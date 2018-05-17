import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../../service/auth.service';
import { LoadingService } from '../../../loading/service/loading.service';
import { AccountHttpService } from '../../../account/service/account-http.service';
import { DialogService } from '../../../shared/service/dialog.service';
import { Login } from '../../';
import { AccountHelpers } from '../../../account/helpers/account.helper';
import { UserProfileHttpService } from '../../../profile/service/user-profile-http.service';
import { ProjectHttpService } from '../../../projects/service/project-http.service';

@Component({
    templateUrl: 'login.component.html',
})
export class LoginComponent implements OnInit  {

    login: Login;
    returnUrl: string;

    constructor(
        private _authService: AuthService,
        private _loadingService: LoadingService,
        private _accountService: AccountHttpService,
        private _userProfileHttpService: UserProfileHttpService,
        private _projectHttpService: ProjectHttpService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
        this.login = new Login();
    }

    ngOnInit() {
      // get return url from route parameters or default to '/'
      this.returnUrl = this._route.snapshot.queryParams['returnUrl'] || '/';
    }

    doLogin(){
        let loadingId = this._loadingService.startLoading();

        this._authService.login(this.login).then((data) => {
            this._router.navigateByUrl(this.returnUrl);
            this._userProfileHttpService.getSummary().then((profileData) => {
                AccountHelpers.setUser(profileData);
            });
            this._accountService.getProjectPermissions().then((permissionData) => {
                AccountHelpers.setPermissions(permissionData);
            });
            this._projectHttpService.getSummaries().then((projectSummaries) => {
                AccountHelpers.setUserProjects(projectSummaries);
            });
        }).catch()
        .then(() => this._loadingService.endLoading(loadingId));
    }
}