import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AccountHelpers } from '../../shared/children/account';

@Injectable()
export class AdminGuard implements CanActivate {

    constructor(private router: Router) { }

    public canActivate() {
        if (!AccountHelpers.isAdmin()) {
            this.router.navigate(['/']);
            return false;
        }
        return true;
    }
}
