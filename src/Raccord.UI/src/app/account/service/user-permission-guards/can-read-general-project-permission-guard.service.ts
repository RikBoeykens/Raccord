import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BaseProjectPermissionGuard } from './base-project-permission-guard.service';
import { ProjectPermissionEnum } from '../../../shared/children/users/project-roles/enums/project-permission.enum';

@Injectable()
export class CanReadGeneralProjectPermissionGuard extends BaseProjectPermissionGuard {

    constructor(router: Router) {
        super(router, ProjectPermissionEnum.canReadGeneral);
     }
}