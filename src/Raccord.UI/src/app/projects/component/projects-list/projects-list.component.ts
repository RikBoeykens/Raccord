import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectHttpService } from '../../service/project-http.service';
import { ProjectSummary } from '../../model/project-summary.model';
import { LoadingService } from '../../../loading/service/loading.service';
import { DialogService } from '../../../shared/service/dialog.service';
import { Image } from '../../children/images/model/image.model';
import { UserProject } from '../../model/user-project.model';

@Component({
    templateUrl: 'projects-list.component.html',
})
export class ProjectsListComponent implements OnInit {

    projects: UserProject[] = [];

    constructor(
        private _projectHttpService: ProjectHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { projects: UserProject[] }) => {
            this.projects = data.projects;
        });
    }

    getProjects(){
        
        let loadingId = this._loadingService.startLoading();

        this._projectHttpService.getAll().then(data => {
            this.projects = data;
            this._loadingService.endLoading(loadingId);
        });
    }
}