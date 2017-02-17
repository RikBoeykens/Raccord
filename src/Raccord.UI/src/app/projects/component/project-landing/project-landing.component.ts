import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectHttpService } from '../../service/project-http.service';
import { FullProject } from '../../model/full-project.model';

@Component({
    templateUrl: 'project-landing.component.html',
})
export class ProjectLandingComponent {

    project: FullProject;

    constructor(
        private _projectHttpService: ProjectHttpService,
        private route: ActivatedRoute,
        private router: Router
    ){
    }

    ngOnInit() {
        this.route.data.subscribe((data: { project: FullProject }) => {
            this.project = data.project;
        });
    }
}