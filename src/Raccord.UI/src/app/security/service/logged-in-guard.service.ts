import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { CanActivate } from '@angular/router';
import { AuthService } from './auth.service';
import { RouteSettings } from '../../shared';

@Injectable()
export class LoggedInGuard implements CanActivate {

    constructor(private authService: AuthService, private router: Router) { }

    public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.authService.loggedIn()) {
            this.router.navigate(
                [`/${RouteSettings.DASHBOARD}`]
            );
            return false;
        }
        return true;
    }
}
