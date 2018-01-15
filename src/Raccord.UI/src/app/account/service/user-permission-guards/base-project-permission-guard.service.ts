import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CanActivate } from '@angular/router';
import { AccountHelpers } from '../../helpers/account.helper';
import { ActivatedRouteSnapshot } from '@angular/router/src/router_state';
import { ProjectPermissionEnum } from '../../../shared/children/users/project-roles/enums/project-permission.enum';

@Injectable()
export abstract class BaseProjectPermissionGuard implements CanActivate {
    private permission: ProjectPermissionEnum;

    constructor(private router: Router, permission: ProjectPermissionEnum) {
        this.permission = permission;
     }

    public canActivate(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        if (!AccountHelpers.hasProjectPermission(projectId, this.permission)) {
            this.router.navigate(['/']);
            return false;
        }
        return true;
    }
}