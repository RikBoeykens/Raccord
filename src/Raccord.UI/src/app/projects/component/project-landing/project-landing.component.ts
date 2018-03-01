import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FullProject } from '../../model/full-project.model';
import { CommentHttpService } from '../../children/comments/service/comment-http.service';
import { AccountHelpers } from '../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from
    '../../../shared/children/users/project-roles/enums/project-permission.enum';
import { CrewUnitNavEnum } from '../../children/crew/crew-units/enum/crew-unit-nav.enum';

@Component({
    templateUrl: 'project-landing.component.html',
})
export class ProjectLandingComponent implements OnInit {

    public project: FullProject;

    constructor(
        private _commentHttpService: CommentHttpService,
        private route: ActivatedRoute,
        private router: Router
    ) {
    }

    public ngOnInit() {
        this.route.data.subscribe((data: { project: FullProject }) => {
            this.project = data.project;
        });
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canEditGeneral
        );
    }

    public getCanRead() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canReadGeneral
        );
    }

    public getCanReadCallsheet() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canReadCallsheet
        );
    }

    public getCanComment() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.CanComment
        );
    }

    public getUnitListNavType() {
        return CrewUnitNavEnum.unitLists;
    }

    public getScheduleEditNavType() {
        return CrewUnitNavEnum.scheduleEdit;
    }

    public getScheduleReadNavType() {
        return CrewUnitNavEnum.scheduleRead;
    }
}
