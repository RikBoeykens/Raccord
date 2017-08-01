import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CanActivate } from '@angular/router';
import { AccountHelpers } from '../../../account/helpers/account.helper';
 
@Injectable()
export class AdminGuard implements CanActivate {
 
    constructor(private router: Router) { }
 
    canActivate() {
        if (!AccountHelpers.isAdmin()) {
            this.router.navigate(['/']);
            return false;
        }
        return true;
    }
}