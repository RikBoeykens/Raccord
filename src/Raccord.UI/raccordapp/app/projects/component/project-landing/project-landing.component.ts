import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectService } from '../../service/project.service';
import { Project } from '../../model/project.model';

@Component({
    templateUrl: 'project-landing.component.html',
    providers: [
        ProjectService
    ]
})
export class ProjectLandingComponent {

    project: Project;

    constructor(
        private projectService: ProjectService,
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