import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FullProject } from '../../model/full-project.model';
import { CommentHttpService } from '../../children/comments/service/comment-http.service';
import { AccountHelpers } from '../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from '../../../shared/children/users/project-roles/enums/project-permission.enum';

@Component({
    templateUrl: 'project-landing.component.html',
})
export class ProjectLandingComponent {

    project: FullProject;

    constructor(
        private _commentHttpService: CommentHttpService,
        private route: ActivatedRoute,
        private router: Router
    ){
    }

    ngOnInit() {
        this.route.data.subscribe((data: { project: FullProject }) => {
            this.project = data.project;
        });
    }

    getCanRead() {
        return AccountHelpers.hasProjectPermission(this.project.id, ProjectPermissionEnum.canReadGeneral);
    }

    getCanReadCallsheet() {
        return AccountHelpers.hasProjectPermission(this.project.id, ProjectPermissionEnum.canReadCallsheet);
    }

    getCanComment() {
        return AccountHelpers.hasProjectPermission(this.project.id, ProjectPermissionEnum.CanComment);
    }
}