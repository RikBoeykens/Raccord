import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { AuthService } from "../security/service/auth.service";
import { AccountHelpers } from "../account/helpers/account.helper";

@Component({
    selector: 'raccord-navbar',
    styleUrls: ['navbar.component.css'],
    templateUrl: 'navbar.component.html',
})
export class NavbarComponent {
    
    constructor(
        private _authService: AuthService,
        private _router: Router
    ){
    }

    loggedIn():boolean{
        return this._authService.loggedIn();
    }

    isAdmin(): boolean{
        return AccountHelpers.isAdmin();
    }

    getUserName(): string{
        return AccountHelpers.getName();
    }

    logOff(){
        this._authService.logout();
        this._router.navigate(["/login"]);
    }
}