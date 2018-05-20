import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectHttpService } from '../../service/project-http.service';
import { ProjectSummary } from '../../model/project-summary.model';
import { Image } from '../../children/images/model/image.model';
import { UserProject } from '../../model/user-project.model';
import { LoadingWrapperService } from '../../../shared/service/loading-wrapper.service';

@Component({
    templateUrl: 'projects-list.component.html',
})
export class ProjectsListComponent implements OnInit {

    public projects: UserProject[] = [];

    constructor(
        private _projectHttpService: ProjectHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _route: ActivatedRoute,
        private _router: Router
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: { projects: UserProject[] }) => {
            this.projects = data.projects;
        });
    }

    public getProjects() {
        this._loadingWrapperService.Load(
            this._projectHttpService.getAll(),
            (data) => this.projects = data
        );
    }
}