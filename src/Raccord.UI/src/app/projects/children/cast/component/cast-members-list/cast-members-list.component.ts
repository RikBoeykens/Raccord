import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { CastMemberSummary } from '../../model/cast-member-summary.model';

@Component({
    templateUrl: 'cast-members-list.component.html',
})
export class CastMembersListComponent implements OnInit {

    public castMembers: CastMemberSummary[];
    public project: ProjectSummary;

    constructor(
        private _route: ActivatedRoute,
        private _router: Router
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data:
            {
                castMembers: CastMemberSummary[],
                project: ProjectSummary
            }) => {
            this.castMembers = data.castMembers;
            this.project = data.project;
        });
    }

    public getFullName(castMember: CastMemberSummary) {
        return `${castMember.firstName} ${castMember.lastName}`;
    }
}
