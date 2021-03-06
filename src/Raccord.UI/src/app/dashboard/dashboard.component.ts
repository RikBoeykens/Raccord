import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedData } from '../shared/children/paging';
import { UserProject } from '../shared/children/projects';
import { RouteSettings } from '../shared';

@Component({
    templateUrl: 'dashboard.component.html',
})
export class DashboardComponent implements OnInit {
    public pagedProjects: PagedData<UserProject>;

    constructor(
        private _route: ActivatedRoute
    ) {}

    public ngOnInit() {
        this._route.data.subscribe((data: { projects: PagedData<UserProject>}) => {
            this.pagedProjects = data.projects;
        });
    }

    public getProjectsLink() {
        return `/${RouteSettings.PROJECTS}`;
    }

    public getProjectLink(project: UserProject) {
        return `/${RouteSettings.PROJECTS}/${project.id}`;
    }
}
