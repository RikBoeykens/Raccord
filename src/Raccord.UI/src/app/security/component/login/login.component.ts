import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../service/auth.service';
import { LoadingService } from '../../../loading/service/loading.service';
import { DialogService } from '../../../shared/service/dialog.service';
import { Login } from '../../';

@Component({
    templateUrl: 'login.component.html',
})
export class LoginComponent {

    login: Login;

    constructor(
        private _authService: AuthService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _router: Router
    ){
        this.login = new Login();
    }

    doLogin(){
        let loadingId = this._loadingService.startLoading();

        this._authService.login(this.login).then(data=>{
            this._router.navigate(['/']);
        }).catch()
        .then(()=> this._loadingService.endLoading(loadingId));
    }
}