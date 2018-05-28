import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../../service/auth.service';
import { LoadingService } from '../../../loading/service/loading.service';
import { AccountHttpService } from '../../../account/service/account-http.service';
import { DialogService } from '../../../shared/service/dialog.service';
import { Login } from '../../';
import { LoginService } from './../../service/login.service';
import { LoadingWrapperService } from '../../../shared/service/loading-wrapper.service';

@Component({
    templateUrl: 'login.component.html',
})
export class LoginComponent implements OnInit  {

    login: Login;
    returnUrl: string;

    constructor(
        private _loginService: LoginService,
        private _loadingWrapperService: LoadingWrapperService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
        this.login = new Login();
    }

    public ngOnInit() {
      // get return url from route parameters or default to '/'
      this.returnUrl = this._route.snapshot.queryParams['returnUrl'] || '/';
    }

    public doLogin() {
        this._loadingWrapperService.Load(
            this._loginService.login(this.login),
            () => this._router.navigateByUrl(this.returnUrl)
        );
    }
}
