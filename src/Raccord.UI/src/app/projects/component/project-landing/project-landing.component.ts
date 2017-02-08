import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectHttpService } from '../../service/project-http.service';
import { Project } from '../../model/project.model';

@Component({
    templateUrl: 'project-landing.component.html',
    providers: [
        ProjectHttpService
    ]
})
export class ProjectLandingComponent {

    project: Project;

    constructor(
        private _projectHttpService: ProjectHttpService,
        private route: ActivatedRoute,
        private router: Router
    ){
    }

    ngOnInit() {
        this.route.data.subscribe((data: { project: Project }) => {
            this.project = data.project;
        });
    }
}