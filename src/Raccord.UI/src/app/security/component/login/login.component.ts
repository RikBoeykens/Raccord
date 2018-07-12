import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Login } from '../..';
import { LoginService } from '../../service/login.service';
import { LoadingWrapperService } from '../../../shared/service/loading-wrapper.service';

@Component({
    templateUrl: 'login.component.html',
})
export class LoginComponent implements OnInit  {
    public login: Login;
    public returnUrl: string;

    constructor(
        private _loginService: LoginService,
        private _loadingWrapperService: LoadingWrapperService,
        private _route: ActivatedRoute,
        private _router: Router
    ) {
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
